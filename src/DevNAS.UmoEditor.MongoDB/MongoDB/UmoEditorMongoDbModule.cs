using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace DevNAS.UmoEditor.MongoDB;

[DependsOn(
    typeof(UmoEditorDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class UmoEditorMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<UmoEditorMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
