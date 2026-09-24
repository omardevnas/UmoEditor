using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(UmoEditorApplicationModule),
    typeof(UmoEditorDomainTestModule)
    )]
public class UmoEditorApplicationTestModule : AbpModule
{

}
