using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DevNAS.UmoEditor.EntityFrameworkCore;

[ConnectionStringName(UmoEditorDbProperties.ConnectionStringName)]
public class UmoEditorDbContext : AbpDbContext<UmoEditorDbContext>, IUmoEditorDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public UmoEditorDbContext(DbContextOptions<UmoEditorDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureUmoEditor();
    }
}
