using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Entities;
using WEB_053502_Raniuk.Data;
using WEB_053502_Raniuk.Extensions;
using WEB_053502_Raniuk.Models;

namespace WEB_053502_Raniuk.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly int _pageSize = 3;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
       
    }
    // GET
    // [Route("Catalog")]
    // [Route("Catalog/Page_{pageNo}")]
    public async Task<IActionResult> Index(int? group, int pageNo = 1)
    {
        var filmsFiltered = _context.Films
            .Where(d => !group.HasValue || d.CategoryId == group.Value);

        ViewData["Categories"] = _context.Categories;
        if (group == 0) group = null;
        var items = ListViewModel<Film>.GetModel(filmsFiltered, pageNo, _pageSize );
        
        var currentGroup = group.HasValue
            ? group.Value
            : 0;
            
        ViewData["CurrentGroup"] = currentGroup;
        if (Request.IsAjaxRequest())
            return PartialView("_ListPartial", ListViewModel<Film>.GetModel(filmsFiltered, pageNo, _pageSize));
        return View(ListViewModel<Film>.GetModel(filmsFiltered, pageNo, _pageSize));
    }
}