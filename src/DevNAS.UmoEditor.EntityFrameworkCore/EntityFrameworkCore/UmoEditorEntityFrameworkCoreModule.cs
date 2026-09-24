using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor.EntityFrameworkCore;

[DependsOn(
    typeof(UmoEditorDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class UmoEditorEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<UmoEditorDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
