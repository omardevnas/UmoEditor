using DevNAS.UmoEditor.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DevNAS.UmoEditor.Permissions;

public class UmoEditorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UmoEditorPermissions.GroupName, L("Permission:UmoEditor"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UmoEditorResource>(name);
    }
}
