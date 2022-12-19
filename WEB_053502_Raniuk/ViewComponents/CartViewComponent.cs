using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Models;

namespace WEB_053502_Raniuk.ViewComponents;

public class CartViewComponent:ViewComponent
{
    private Cart _cart;
    public CartViewComponent(Cart cart)
    {
        _cart = cart;
    }
    public IViewComponentResult Invoke()
    {
        //var cart = HttpContext.Session.Get<Cart>("cart")??new Cart();
        return View(_cart);
    }
}
    