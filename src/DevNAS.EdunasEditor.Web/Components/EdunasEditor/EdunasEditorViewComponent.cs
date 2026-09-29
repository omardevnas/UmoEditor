using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace DevNAS.EdunasEditor.Web.Components.EdunasEditor;

/// <summary>
/// Reusable rich-text editor widget (Umo Editor / Vue island). Embed it from
/// any Razor page in this module — or any other module/host that references
/// DevNAS.EdunasEditor.Web — with:
/// <code>@await Component.InvokeAsync("EdunasEditor", new EdunasEditorViewModel { ValueJson = json })</code>
/// </summary>
public class EdunasEditorViewComponent : ViewComponent
{
    public const string ViewPath = "~/Components/EdunasEditor/Default.cshtml";

    public IViewComponentResult Invoke(EdunasEditorViewModel? model = null)
    {
        return View(ViewPath, ResolveModel(model));
    }

    /// <summary>Defaults a missing model to a fresh <see cref="EdunasEditorViewModel"/>
    /// and resolves an unset <see cref="EdunasEditorViewModel.Locale"/> from the
    /// ambient request culture — split out from <see cref="Invoke"/> so it's
    /// testable without needing a full MVC <see cref="ViewComponentContext"/>.</summary>
    public static EdunasEditorViewModel ResolveModel(EdunasEditorViewModel? model)
    {
        var resolved = model ?? new EdunasEditorViewModel();
        resolved.Locale ??= ResolveLocaleFromCulture(CultureInfo.CurrentUICulture);
        return resolved;
    }

    /// <summary>Maps an ABP/ASP.NET request culture onto the editor's own
    /// supported locale set. Matches on the two-letter language code so
    /// regional variants (ar-SA, ar-EG, en-GB, …) all resolve correctly.
    /// Anything the editor has no translation for falls back to English.</summary>
    public static EdunasEditorLocale ResolveLocaleFromCulture(CultureInfo culture) =>
        culture.TwoLetterISOLanguageName.Equals("ar", System.StringComparison.OrdinalIgnoreCase)
            ? EdunasEditorLocale.Ar
            : EdunasEditorLocale.En;
}
