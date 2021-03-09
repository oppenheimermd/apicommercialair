using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apicommercialair.core.Models;
using apicommercialair.data;

namespace apicommercialair.web.Pages.Airplanes
{
    public class EditModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        //  SelectList for Manufactures
        public SelectList ManufacturersSL { get; set; }

        public EditModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aircraft Aircraft { get; set; }

        public async Task<List<Manufacturer>> PopulateManufactureresDropDownList()
        {
            return await _context.Manufacturers
                .AsNoTracking()
                .ToListAsync();

        }

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
            var manufacturesDdl = await PopulateManufactureresDropDownList();
            ManufacturersSL = new SelectList(manufacturesDdl, "Id", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var aircraftToUpdate = await _context.Aircraft.FindAsync(id);

            if (aircraftToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Aircraft>(
            aircraftToUpdate,
            /* Looks for form fields with a "aircraft" prefix i.e. Manufacturer.CompanyName. 
             * It's not case sensitive.*/
            "aircraft",
            //  update only the below values
            a => a.Name,
            a => a.AircraftCategory,
            a => a.FirstFlight,
            a => a.Introduction,
            a => a.ManufacturerId
            ))
            {
                await _context.SaveChangesAsync();
                return Redirect("./Index");
            }

            return Page();
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircraft.Any(e => e.Id == id);
        }
    }
}
