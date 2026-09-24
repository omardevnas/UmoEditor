using DevNAS.UmoEditor.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DevNAS.UmoEditor.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class UmoEditorPageModel : AbpPageModel
{
    protected UmoEditorPageModel()
    {
        LocalizationResourceType = typeof(UmoEditorResource);
        ObjectMapperContext = typeof(UmoEditorWebModule);
    }
}
