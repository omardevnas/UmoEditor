using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DevNAS.UmoEditor.EntityFrameworkCore;

[ConnectionStringName(UmoEditorDbProperties.ConnectionStringName)]
public interface IUmoEditorDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
