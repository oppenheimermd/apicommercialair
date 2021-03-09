using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using apicommercialair.core.Models;
using apicommercialair.data;

namespace apicommercialair.web.Pages.Airplanes
{
    public class DetailsModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public DetailsModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public Aircraft Aircraft { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aircraft = await _context.Aircraft
                .Include(a => a.Manufacturer).FirstOrDefaultAsync(m => m.Id == id);

            if (Aircraft == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
