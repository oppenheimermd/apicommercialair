using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using apicommercialair.core.Models;
using apicommercialair.data;
using Microsoft.EntityFrameworkCore;

namespace apicommercialair.web.Pages.Airplanes
{
    public class CreateModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        //  SelectList for Manufactures
        public SelectList ManufacturersSL { get; set; }

        public async Task<List<Manufacturer>> PopulateManufactureresDropDownList()
        {
            return await _context.Manufacturers
                .AsNoTracking()
                .ToListAsync();
            
        }

        public CreateModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            var manufacturesDdl = await PopulateManufactureresDropDownList();
            ManufacturersSL = new SelectList(manufacturesDdl, "Id", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Aircraft Aircraft { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //  The scaffolded OnPostAsync code for the Create page is vulnerable to
            //  overposting. We remedy this with the following code
            var emptyAircraft = new Aircraft();

            if (await TryUpdateModelAsync<Aircraft>(
            emptyAircraft,
            /* Looks for form fields with a "aircraft" prefix i.e. Manufacturer.CompanyName. 
             * It's not case sensitive.*/
            "aircraft",
            //  update only the below values
            a => a.Name,
            a => a.AircraftCategory,
            a => a.FirstFlight,
            a => a.Introduction,
            a => a.ManufacturerId))
                    {
                        _context.Aircraft.Add(emptyAircraft);
                        await _context.SaveChangesAsync();
                        return Redirect("./Index");
                    }

            return Page();
        }
        
    }
}
