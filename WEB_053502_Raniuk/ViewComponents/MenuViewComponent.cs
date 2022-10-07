using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;


namespace WEB_053502_Raniuk.ViewComponents;

public class MenuViewComponent: ViewComponent
{
    private List<MenuItem> _menuItems = new List<MenuItem>
    {
        new MenuItem{ Controller="Home", Action="Index", Text="Lab 2"},
        new MenuItem{ Controller="Product", Action="Index",
            Text="Каталог"},
        new MenuItem{ IsPage=true, Area="Admin", Page="/Index",
            Text="Администрирование"}
    };

    public IViewComponentResult Invoke()
    {
        var controller = ViewContext.RouteData.Values["controller"];
        var area = ViewContext.RouteData.Values["area"];
        foreach (var menuItem in _menuItems)
        {
            if (controller != null && controller.Equals(menuItem.Controller))
            {
                menuItem.Active = "active";
            }
            else if (area != null && area.Equals(menuItem.Area))
            {
                menuItem.Active= "active";
            }
        }
        return View(_menuItems);
    }       
}