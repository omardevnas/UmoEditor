using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(UmoEditorDomainSharedModule)
)]
public class UmoEditorDomainModule : AbpModule
{

}
