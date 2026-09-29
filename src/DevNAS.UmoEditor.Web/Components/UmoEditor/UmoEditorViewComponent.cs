using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace DevNAS.UmoEditor.Web.Components.UmoEditor;

/// <summary>
/// Reusable rich-text editor widget (Umo Editor / Vue island). Embed it from
/// any Razor page in this module — or any other module/host that references
/// DevNAS.UmoEditor.Web — with:
/// <code>@await Component.InvokeAsync("UmoEditor", new UmoEditorViewModel { ValueJson = json })</code>
/// </summary>
public class UmoEditorViewComponent : ViewComponent
{
    public const string ViewPath = "~/Components/UmoEditor/Default.cshtml";

    public IViewComponentResult Invoke(UmoEditorViewModel? model = null)
    {
        return View(ViewPath, ResolveModel(model));
    }

    /// <summary>Defaults a missing model to a fresh <see cref="UmoEditorViewModel"/>
    /// and resolves an unset <see cref="UmoEditorViewModel.Locale"/> from the
    /// ambient request culture — split out from <see cref="Invoke"/> so it's
    /// testable without needing a full MVC <see cref="ViewComponentContext"/>.</summary>
    public static UmoEditorViewModel ResolveModel(UmoEditorViewModel? model)
    {
        var resolved = model ?? new UmoEditorViewModel();
        resolved.Locale ??= ResolveLocaleFromCulture(CultureInfo.CurrentUICulture);
        return resolved;
    }

    /// <summary>Maps an ABP/ASP.NET request culture onto the editor's own
    /// supported locale set. Matches on the two-letter language code so
    /// regional variants (ar-SA, ar-EG, en-GB, …) all resolve correctly.
    /// Anything the editor has no translation for falls back to English.</summary>
    public static UmoEditorLocale ResolveLocaleFromCulture(CultureInfo culture) =>
        culture.TwoLetterISOLanguageName.Equals("ar", System.StringComparison.OrdinalIgnoreCase)
            ? UmoEditorLocale.Ar
            : UmoEditorLocale.En;
}
