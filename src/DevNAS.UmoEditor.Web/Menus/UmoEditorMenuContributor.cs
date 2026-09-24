using System.Threading.Tasks;
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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(UmoEditorMenus.Prefix, displayName: "UmoEditor", "~/UmoEditor", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
