using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace DevNAS.UmoEditor.Web.Components.UmoEditor;

/// <summary>
/// Stylesheet for the read-only renderer.
/// <para>
/// This intentionally points at the SAME <c>umo-editor-bundle.css</c> the authoring widget uses,
/// rather than emitting a second viewer-specific stylesheet. Umo's content styles are rooted at
/// <c>.umo-editor-content</c> (verified against the built CSS), and
/// <c>DevNasUmoViewer.render()</c> wraps its generated markup in exactly that class — so the
/// authoring stylesheet already styles rendered output correctly. A separate viewer stylesheet
/// would be a near-identical ~480 kB duplicate.
/// </para>
/// <para>
/// Does NOT include host-theme-fixes.css: that file exists to undo a host theme pinning Umo's
/// <c>&lt;header class="umo-toolbar"&gt;</c>, and read-only output contains no toolbar.
/// </para>
/// </summary>
public class UmoEditorViewerStyleContributor : BundleContributor
{
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/Components/UmoEditor/wwwroot/umo/umo-editor-bundle.css");
        return Task.CompletedTask;
    }
}
