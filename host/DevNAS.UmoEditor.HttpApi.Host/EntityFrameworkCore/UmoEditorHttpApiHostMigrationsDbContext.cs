using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DevNAS.UmoEditor.EntityFrameworkCore;

public class UmoEditorHttpApiHostMigrationsDbContext : AbpDbContext<UmoEditorHttpApiHostMigrationsDbContext>
{
    public UmoEditorHttpApiHostMigrationsDbContext(DbContextOptions<UmoEditorHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUmoEditor();
    }
}
