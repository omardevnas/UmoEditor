using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DevNAS.UmoEditor;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class UmoEditorInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UmoEditorInstallerModule>();
        });
    }
}
