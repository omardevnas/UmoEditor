using Localization.Resources.AbpUi;
using DevNAS.UmoEditor.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class UmoEditorHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(UmoEditorHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<UmoEditorResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
