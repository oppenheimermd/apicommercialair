using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using apicommercialair.core.Models;
using apicommercialair.data;

namespace apicommercialair.web.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public DetailsModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  The Include and ThenInclude methods cause the context to load the
            //      Manufacturers.Aircraft
            //      Aircraft.Variants(each)
            //      Variant.Images(each)
            //
            //  See: Part 6, Razor Pages with EF Core in ASP.NET Core - Read Related Data
            //  https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-5.0&tabs=visual-studio
            Manufacturer = await _context.Manufacturers
                .Include(m => m.Aircraft)
                .ThenInclude(v => v.Variants)
                .ThenInclude(i => i.AircraftImages)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
