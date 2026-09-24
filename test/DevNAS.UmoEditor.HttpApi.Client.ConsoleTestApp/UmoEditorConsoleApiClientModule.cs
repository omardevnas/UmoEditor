using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UmoEditorHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class UmoEditorConsoleApiClientModule : AbpModule
{

}
