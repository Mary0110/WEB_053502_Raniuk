using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_053502_Raniuk.Data;
using WEB_053502_Raniuk.Entities;

namespace WEB_053502_Raniuk.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_053502_Raniuk.Data.ApplicationDbContext _context;

        public CreateModel(WEB_053502_Raniuk.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || 
              _context.Films == null ||
              Film == null)
            {
                return Page();
            }

            _context.Films.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
