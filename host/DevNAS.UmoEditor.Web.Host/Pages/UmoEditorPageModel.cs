using DevNAS.UmoEditor.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DevNAS.UmoEditor.Pages;

public abstract class UmoEditorPageModel : AbpPageModel
{
    protected UmoEditorPageModel()
    {
        LocalizationResourceType = typeof(UmoEditorResource);
    }
}
