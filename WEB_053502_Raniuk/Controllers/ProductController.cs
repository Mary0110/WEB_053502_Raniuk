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

        //var list = _context.Films;
        ViewData["Categories"] = _categoryList;
        if (category == 0) category = null;
        var items = ListViewModel<Film>.GetModel(filmsFiltered, pageNo, _pageSize );
        
        var currentGroup = category.HasValue
            ? category.Value
            : 0;
            
        ViewData["CurrentGroup"] = currentGroup;
        return View(items);
    }
    
    // public IActionResult Create()
    // {
    //     return View();
    // }
    //
    // // POST: Accessory/Create
    // // To protect from overposting attacks, enable the specific properties you want to bind to.
    // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create([Bind("Id,Name,Description,Category,CategoryId,Image")] Film film)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Add(film);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(film);
    // }
}