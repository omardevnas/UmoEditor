using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace DevNAS.EdunasEditor.Web.Components.EdunasEditor;

/// <summary>
/// Registers the READ-ONLY renderer (<c>window.DevNasUmoViewer</c>) for pages that display
/// editor content but never author it.
/// <para>
/// A page must load EXACTLY ONE of the two bundles. <see cref="EdunasEditorScriptContributor"/>
/// already includes the viewer API, so an authoring page needs only that one and must NOT also
/// register this contributor — the two bundles are ~3 MB each and largely overlap (29 of Umo's
/// extensions statically import <c>@tiptap/vue-3</c> and their node views, which is why the
/// viewer-only build is 2.88 MB against the editor's 3.20 MB rather than a fraction of it).
/// </para>
/// <para>
/// Use this one on display-only pages — a student sitting an exam, a results screen, a grading
/// review. <c>DevNasUmoViewer.render(el, json)</c> is a pure JSON-to-HTML call with no Vue app
/// mounted, so a page showing many documents at once pays for one module evaluation plus one
/// <c>innerHTML</c> assignment per document.
/// </para>
/// <code>
/// &lt;abp-script-bundle&gt;
///     &lt;abp-script type="typeof(EdunasEditorViewerScriptContributor)" /&gt;
/// &lt;/abp-script-bundle&gt;
/// </code>
/// </summary>
public class EdunasEditorViewerScriptContributor : BundleContributor
{
    public override Task ConfigureBundleAsync(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/umo/umo-viewer-bundle.js");
        return Task.CompletedTask;
    }
}
