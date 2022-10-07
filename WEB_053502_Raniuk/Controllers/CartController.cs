namespace WEB_053502_Raniuk.Controllers;

using Microsoft.AspNetCore.Mvc;

public class CartController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}