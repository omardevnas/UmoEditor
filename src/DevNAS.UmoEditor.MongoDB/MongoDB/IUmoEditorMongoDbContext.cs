using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DevNAS.UmoEditor.MongoDB;

[ConnectionStringName(UmoEditorDbProperties.ConnectionStringName)]
public interface IUmoEditorMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
