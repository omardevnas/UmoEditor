using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorDomainModule),
    typeof(UmoEditorTestBaseModule)
)]
public class UmoEditorDomainTestModule : AbpModule
{

}
