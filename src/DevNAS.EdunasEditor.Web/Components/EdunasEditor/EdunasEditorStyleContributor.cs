using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace DevNAS.EdunasEditor.Web.Components.EdunasEditor;

/// <summary>
/// Registers the DevNAS EdunasEditor widget's stylesheet (Umo's own Vite-built
/// CSS, vendored from the standalone umo-build project) into ABP's style
/// bundling pipeline. Page-scoped only — see EdunasEditorScriptContributor's
/// remarks. Consume from a page with:
/// <code>
/// &lt;abp-style-bundle&gt;
///     &lt;abp-style type="typeof(EdunasEditorStyleContributor)" /&gt;
/// &lt;/abp-style-bundle&gt;
/// </code>
/// </summary>
public class EdunasEditorStyleContributor : BundleContributor
{
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/wwwroot/umo/umo-editor-bundle.css");

        // Must come AFTER the bundle: these rules undo host-theme CSS that reaches into the
        // widget's DOM (e.g. Lepton pinning Umo's <header class="umo-toolbar"> to the top of
        // the viewport). Kept separate from the vendored bundle because that file is build
        // output and gets overwritten on every umo-build rebuild. See the file's own comments.
        context.Files.AddIfNotContains("/Components/EdunasEditor/host-theme-fixes.css");

        return Task.CompletedTask;
    }
}
