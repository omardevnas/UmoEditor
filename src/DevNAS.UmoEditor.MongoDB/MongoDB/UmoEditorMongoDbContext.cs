using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DevNAS.UmoEditor.MongoDB;

[ConnectionStringName(UmoEditorDbProperties.ConnectionStringName)]
public class UmoEditorMongoDbContext : AbpMongoDbContext, IUmoEditorMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureUmoEditor();
    }
}
