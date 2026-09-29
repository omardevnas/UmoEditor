using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace DevNAS.EdunasEditor.Web.Components.EdunasEditor;

/// <summary>
/// Registers the DevNAS EdunasEditor widget's scripts into ABP's script
/// bundling pipeline. Page-scoped only — register this contributor ONLY on
/// pages that actually embed the widget, never globally, so Vue's payload
/// never loads on a page that doesn't use it.
///
/// Two files, in order: the Vite-built <c>umo-editor-bundle.js</c> (an ES
/// module — Vue/Umo/vue-i18n/our custom extensions, all inlined; vendored
/// here from the standalone <c>umo-build</c> project, see that project's
/// README.md, NOT fetched via abp.resourcemapping.js/abp install-libs,
/// since it isn't a host-scoped node_modules-sourced library once vendored
/// into this RCL) loaded as a classic script with type="module" so ABP's
/// bundler (a plain concatenator, not a real bundler — it does not compile
/// or resolve imports) just serves it as-is; then <c>umo-loader.js</c>, a
/// plain classic script providing the jQuery-plugin convenience layer.
/// Consume from a page with:
/// <code>
/// &lt;abp-script-bundle&gt;
///     &lt;abp-script type="typeof(EdunasEditorScriptContributor)" /&gt;
/// &lt;/abp-script-bundle&gt;
/// </code>
/// </summary>
public class EdunasEditorScriptContributor : BundleContributor
{
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/wwwroot/umo/umo-editor-bundle.js");
        context.Files.AddIfNotContains("/Components/EdunasEditor/umo-loader.js");
        return Task.CompletedTask;
    }
}
