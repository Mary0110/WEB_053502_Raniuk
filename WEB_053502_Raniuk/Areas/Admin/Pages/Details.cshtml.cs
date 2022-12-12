using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Raniuk.Data;
using WEB_053502_Raniuk.Entities;

namespace WEB_053502_Raniuk.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_053502_Raniuk.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_053502_Raniuk.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Film Film { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }
    }
}
