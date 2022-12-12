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
    public class IndexModel : PageModel
    {
        private readonly WEB_053502_Raniuk.Data.ApplicationDbContext _context;

        public IndexModel(WEB_053502_Raniuk.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Films != null)
            {
                Film = await _context.Films.ToListAsync();
            }
        }
    }
}
