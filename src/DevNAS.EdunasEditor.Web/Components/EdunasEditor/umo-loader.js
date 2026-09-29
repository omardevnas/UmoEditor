// Public entry point for the DevNAS UmoEditor widget. Loaded as a plain
// classic script (via EdunasEditorScriptContributor, AFTER the big Vite-built
// umo-editor-bundle.js module has run and set window.DevNasUmo — see
// Default.cshtml), so this file itself needs no bundler/ESM support and can
// use the same jQuery-plugin convention as DevNAS.Editor's own
// editor-loader.js: `window.DevNasUmoEditor` + `$.fn.devnasUmoEditor`.
(function () {
  function resolveElement(target) {
    if (typeof target === "string") return document.querySelector(target);
    return target;
  }

  // Thin registry over window.DevNasUmo.create/get/destroy (the low-level
  // per-element API the Vite bundle exposes) — adds auto-scan and the
  // declarative hidden-form-field binding DevNAS.Editor's widget also has.
  var UmoEditorRegistry = /** @class */ (function () {
    function UmoEditorRegistry() {
      this._elements = [];
    }

    UmoEditorRegistry.prototype.create = function (target, options) {
      var el = resolveElement(target);
      if (!el) throw new Error("DevNasUmoEditor.create: target element not found");
      var existing = window.DevNasUmo.get(el);
      if (existing) return existing;

      var instance = window.DevNasUmo.create(el, options || {});
      this._elements.push(el);
      el.setAttribute("data-devnas-umo-editor-ready", "true");

      // Declarative form binding: <div data-devnas-umo-editor-form-field="my-hidden-id">
      // keeps that hidden field's value in sync with the editor's JSON content —
      // mirrors DevNAS.Editor's own EditorViewModel.FormFieldName convention,
      // but serializes getJSON() instead of getMarkdown(), since JSON is this
      // widget's only content format.
      var formFieldId = el.getAttribute("data-devnas-umo-editor-form-field");
      if (formFieldId) {
        var hidden = document.getElementById(formFieldId);
        if (hidden) {
          var syncHiddenField = function () {
            hidden.value = JSON.stringify(instance.getJSON());
          };
          syncHiddenField();
          // Two sync points, both cheap:
          //   focusout - the common case, when the author moves on to another control.
          //   devnas-umo-editor:save - raised by our onSave handler, so Umo's autosave timer and
          //                            Ctrl+S both commit the current content to the field instead
          //                            of erroring. Without an onSave, Umo's default rejects and
          //                            logs 'Key "onSave": Please set the save method'.
          el.addEventListener("focusout", syncHiddenField, true);
          el.addEventListener("devnas-umo-editor:save", syncHiddenField);
        }
      }

      el.dispatchEvent(new CustomEvent("devnas-umo-editor:ready", { detail: instance, bubbles: true }));
      return instance;
    };

    UmoEditorRegistry.prototype.get = function (target) {
      var el = resolveElement(target);
      return el ? window.DevNasUmo.get(el) : undefined;
    };

    UmoEditorRegistry.prototype.destroy = function (target) {
      var el = resolveElement(target);
      if (!el) return;
      window.DevNasUmo.destroy(el);
      var idx = this._elements.indexOf(el);
      if (idx !== -1) this._elements.splice(idx, 1);
    };

    UmoEditorRegistry.prototype.scan = function (root) {
      root = root || document;
      var nodes = root.querySelectorAll("[data-devnas-umo-editor]:not([data-devnas-umo-editor-ready])");
      for (var i = 0; i < nodes.length; i++) {
        var el = nodes[i];
        var options = {};
        var raw = el.getAttribute("data-devnas-umo-editor-options");
        if (raw) {
          try {
            options = JSON.parse(raw);
          } catch (err) {
            console.error("DevNasUmoEditor: invalid data-devnas-umo-editor-options JSON", err);
            continue;
          }
        }
        this.create(el, options);
      }
    };

    return UmoEditorRegistry;
  })();

  var registry = new UmoEditorRegistry();

  var DevNasUmoEditor = {
    create: function (target, options) {
      return registry.create(target, options);
    },
    get: function (target) {
      return registry.get(target);
    },
    destroy: function (target) {
      return registry.destroy(target);
    },
    scan: function (root) {
      return registry.scan(root);
    },
  };

  window.DevNasUmoEditor = Object.assign(window.DevNasUmoEditor || {}, DevNasUmoEditor);

  if (window.jQuery) {
    window.jQuery.fn.devnasUmoEditor = function devnasUmoEditorPlugin(optionsOrCommand) {
      var args = Array.prototype.slice.call(arguments, 1);
      if (typeof optionsOrCommand === "string") {
        var instance = registry.get(this[0]);
        if (!instance) return undefined;
        if (optionsOrCommand === "instance") return instance;
        var method = instance[optionsOrCommand];
        if (typeof method !== "function") {
          console.error('DevNasUmoEditor: unknown command "' + optionsOrCommand + '"');
          return undefined;
        }
        return method.apply(instance, args);
      }
      return this.each(function initOne() {
        registry.create(this, optionsOrCommand || {});
      });
    };
  }

  function ready() {
    registry.scan();
  }

  // window.DevNasUmo is set as a side effect of the Vite bundle's module
  // script — that <script type="module"> is deferred by spec, so by the
  // time this classic script runs, it may or may not have executed yet.
  // Poll briefly rather than assuming an order, since ABP's bundle
  // contributor loads both from the same <abp-script-bundle> and module
  // execution timing relative to classic scripts isn't guaranteed.
  function whenBundleReady(callback, attemptsLeft) {
    if (window.DevNasUmo) {
      callback();
      return;
    }
    if (attemptsLeft <= 0) {
      console.error("DevNasUmoEditor: window.DevNasUmo never became available — umo-editor-bundle.js failed to load?");
      return;
    }
    setTimeout(function () {
      whenBundleReady(callback, attemptsLeft - 1);
    }, 20);
  }

  function start() {
    whenBundleReady(ready, 250); // ~5s worst case
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", start);
  } else {
    start();
  }
})();
