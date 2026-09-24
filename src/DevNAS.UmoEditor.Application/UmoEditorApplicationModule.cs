using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorDomainModule),
    typeof(UmoEditorApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class UmoEditorApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<UmoEditorApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<UmoEditorApplicationModule>(validate: true);
        });
    }
}
