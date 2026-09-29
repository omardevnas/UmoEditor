using System.Threading.Tasks;
using DevNAS.UmoEditor.Localization;
using Volo.Abp.UI.Navigation;

namespace DevNAS.UmoEditor.Web.Menus;

public class UmoEditorMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<UmoEditorResource>();

        context.Menu.AddItem(new ApplicationMenuItem(UmoEditorMenus.UmoEditor, l["Menu:UmoEditor"], "~/UmoEditor", icon: "fa fa-file-word-o"));

        return Task.CompletedTask;
    }
}
