using Volo.Abp;
using Volo.Abp.MongoDB;

namespace DevNAS.UmoEditor.MongoDB;

public static class UmoEditorMongoDbContextExtensions
{
    public static void ConfigureUmoEditor(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
