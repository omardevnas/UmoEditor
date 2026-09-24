using Volo.Abp.Reflection;

namespace DevNAS.UmoEditor.Permissions;

public class UmoEditorPermissions
{
    public const string GroupName = "UmoEditor";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(UmoEditorPermissions));
    }
}
