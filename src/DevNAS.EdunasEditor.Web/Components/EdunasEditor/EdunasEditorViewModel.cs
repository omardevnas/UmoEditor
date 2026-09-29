using System;

namespace DevNAS.EdunasEditor.Web.Components.EdunasEditor;

/// <summary>
/// Options for one embedding of the reusable DevNAS EdunasEditor widget. Any
/// Razor page/component in this module — or in another module/host that
/// references DevNAS.EdunasEditor.Web — can render an instance via:
/// <code>@await Component.InvokeAsync("EdunasEditor", new EdunasEditorViewModel { ... })</code>
/// </summary>
public class EdunasEditorViewModel
{
    /// <summary>DOM id for the widget root. Auto-generated if not set.</summary>
    public string Id { get; set; } = "devnas-umo-editor-" + Guid.NewGuid().ToString("N");

    /// <summary>Initial content as a serialized ProseMirror JSON string (the
    /// widget's only supported content format — Umo has no markdown import
    /// path, and JSON is this project's canonical storage format regardless).
    /// Leave null/empty for a blank document.</summary>
    public string? ValueJson { get; set; }

    /// <summary>UI locale for the editor's own toolbar/menu chrome.
    /// Leave null (the default) to follow ABP's current request culture, so
    /// the editor switches language along with the rest of the page when the
    /// user uses ABP's language switcher. Set it explicitly only to pin one
    /// embedding to a specific language regardless of the ambient culture.</summary>
    public EdunasEditorLocale? Locale { get; set; }

    public bool ReadOnly { get; set; }

    /// <summary><see cref="EdunasEditorToolbarMode.None"/> hides Umo's ribbon
    /// toolbar (e.g. for a read-only student-view mirror).</summary>
    public EdunasEditorToolbarMode Toolbar { get; set; } = EdunasEditorToolbarMode.Full;

    /// <summary>Whether the Fill-in-the-Blank node reveals its answer (author
    /// view) or renders a blanked-out placeholder (student view).</summary>
    public bool RevealAnswer { get; set; } = true;

    /// <summary>Extra CSS class(es) applied to the widget root element.</summary>
    public string? CssClass { get; set; }

    /// <summary>When set, a hidden `&lt;textarea&gt;` with this `name` is rendered
    /// next to the widget and kept in sync with the editor's JSON content —
    /// lets the widget participate in a classic ASP.NET Core form post/model
    /// binding without any extra JS wiring from the consuming page.
    /// <para>Mutually exclusive with <see cref="BoundFieldId"/>.</para></summary>
    public string? FormFieldName { get; set; }

    /// <summary>
    /// Id of an EXISTING form field on the page to keep in sync, instead of rendering a new one.
    /// <para>
    /// Use this when the page already owns the input and its attributes matter — e.g. the
    /// examination answer inputs, which carry specific <c>class</c> and <c>name</c> values that
    /// existing submit code selects on. <see cref="FormFieldName"/> would render a second,
    /// competing field in those cases.
    /// </para>
    /// <para>
    /// The referenced element must already hold the same content passed as
    /// <see cref="ValueJson"/>; the widget overwrites it on mount and on every blur, but does not
    /// seed it. Mutually exclusive with <see cref="FormFieldName"/> — setting both throws.
    /// </para>
    /// </summary>
    public string? BoundFieldId { get; set; }
}
