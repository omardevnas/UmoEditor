using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevNAS.UmoEditor.EntityFrameworkCore;

public class UmoEditorHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<UmoEditorHttpApiHostMigrationsDbContext>
{
    public UmoEditorHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<UmoEditorHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("UmoEditor"));

        return new UmoEditorHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
