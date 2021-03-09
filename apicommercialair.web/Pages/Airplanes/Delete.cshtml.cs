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
    public class DeleteModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public DeleteModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aircraft = await _context.Aircraft.FindAsync(id);

            if (Aircraft != null)
            {
                _context.Aircraft.Remove(Aircraft);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
