using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Models;

namespace WEB_053502_Raniuk.ViewComponents;


    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Cart");
        }
        
    }
