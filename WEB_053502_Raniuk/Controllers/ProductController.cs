using Microsoft.AspNetCore.Mvc;
using WEB_053502_Raniuk.Entities;
using WEB_053502_Raniuk.Data;
using WEB_053502_Raniuk.Models;

namespace WEB_053502_Raniuk.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly int _pageSize = 3;
    private readonly List<Category> _categoryList;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
        _categoryList = new List<Category>()
        {
            new Category { Id = 0, CategoryName = "All"},
            new Category { Id = 1, CategoryName = "Films"},
            new Category { Id = 2, CategoryName = "Series"}
        };
    }
    // GET
    public async Task<IActionResult> Index(int? category, int pageNo = 1)
    {
        var filmsFiltered = _context.Films
            .Where(d => !category.HasValue || d.CategoryId == category.Value);

        ViewData["Categories"] = _categoryList;
        if (category == 0) category = null;
        var items = ListViewModel<Film>.GetModel(filmsFiltered, pageNo, _pageSize );
        
        var currentGroup = category.HasValue
            ? category.Value
            : 0;
            
        ViewData["CurrentGroup"] = currentGroup;
        return View(items);
    }
}