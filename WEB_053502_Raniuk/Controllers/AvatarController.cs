using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Entities;

namespace WEB_053502_Raniuk.Controllers;

public class AvatarController : Controller
{
    private UserManager<ApplicationUser> _userManager;
    private IWebHostEnvironment _env;

    public AvatarController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
    {
        _userManager = userManager;
        _env = env;
    }

    public async Task<FileResult> GetAvatar()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user.Avatar != null)
            return File(user.Avatar, "image/...");
        else
        {
            var avatarPath = "/images/avatar.jpeg";
            return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
                .CreateReadStream(), "image/...");
        }
    }
}