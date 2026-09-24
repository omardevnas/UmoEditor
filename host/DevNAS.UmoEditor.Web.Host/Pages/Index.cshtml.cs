using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DevNAS.UmoEditor.Pages;

public class IndexModel : UmoEditorPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
