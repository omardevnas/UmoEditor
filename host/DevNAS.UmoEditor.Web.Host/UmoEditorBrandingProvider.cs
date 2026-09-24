using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DevNAS.UmoEditor;

[Dependency(ReplaceServices = true)]
public class UmoEditorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UmoEditor";
}
