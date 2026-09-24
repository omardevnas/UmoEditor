namespace DevNAS.UmoEditor;

public static class UmoEditorDbProperties
{
    public static string DbTablePrefix { get; set; } = "UmoEditor";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "UmoEditor";
}
