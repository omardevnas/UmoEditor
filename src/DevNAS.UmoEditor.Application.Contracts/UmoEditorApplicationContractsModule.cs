using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class UmoEditorApplicationContractsModule : AbpModule
{

}
