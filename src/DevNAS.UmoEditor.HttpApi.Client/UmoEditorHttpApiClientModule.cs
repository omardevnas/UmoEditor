using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class UmoEditorHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(UmoEditorApplicationContractsModule).Assembly,
            UmoEditorRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UmoEditorHttpApiClientModule>();
        });

    }
}
