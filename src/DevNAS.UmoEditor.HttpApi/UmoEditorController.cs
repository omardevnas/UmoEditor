using DevNAS.UmoEditor.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DevNAS.UmoEditor;

public abstract class UmoEditorController : AbpControllerBase
{
    protected UmoEditorController()
    {
        LocalizationResource = typeof(UmoEditorResource);
    }
}
