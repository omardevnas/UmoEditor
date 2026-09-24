using DevNAS.UmoEditor.Localization;
using Volo.Abp.Application.Services;

namespace DevNAS.UmoEditor;

public abstract class UmoEditorAppService : ApplicationService
{
    protected UmoEditorAppService()
    {
        LocalizationResource = typeof(UmoEditorResource);
        ObjectMapperContext = typeof(UmoEditorApplicationModule);
    }
}
