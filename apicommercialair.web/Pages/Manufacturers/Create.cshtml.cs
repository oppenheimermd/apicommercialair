using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using apicommercialair.core.Models;
using apicommercialair.data;

namespace apicommercialair.web.Pages.Manufacturers
{
    public class CreateModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public CreateModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //  The scaffolded OnPostAsync code for the Create page is vulnerable to
            //  overposting. We remedy this with the following code
            var emptyManufacturer = new Manufacturer();

            if (await TryUpdateModelAsync<Manufacturer>(
                emptyManufacturer,
                /* Looks for form fields with a "manufacturer" prefix i.e. Manufacturer.CompanyName. 
                 * It's not case sensitive.*/
                "manufacturer", 
                //  update only the below values
                m => m.CompanyName, 
                m => m.CompanyAddress, 
                m => m.CompanyWebsite, 
                m => m.CompanyAbout))
            {
                _context.Manufacturers.Add(emptyManufacturer);
                await _context.SaveChangesAsync();
                return Redirect("./Index");
            }

            return Page();
        }
    }
}
