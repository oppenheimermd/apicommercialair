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

namespace apicommercialair.web.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public EditModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  FirstOrDefaultAsync has been replaced with FindAsync.
            //  When you don't have to include related data, FindAsync is more efficient.
            Manufacturer = await _context.Manufacturers.FindAsync(id);
            //Manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //  Like our create page we need to do some changes
            //  to prevent overposting
            //
            //  The current student is fetched from the database, rather than creating
            //  an empty student.
            var manufacturerToUpdate = await _context.Manufacturers.FindAsync(id);

            if (manufacturerToUpdate == null)
            {
                return NotFound();
            }

            //  See note at end of code about EntityState, which was previously
            //  handeled here

            if (await TryUpdateModelAsync<Manufacturer>(
                manufacturerToUpdate,
                "manufacturer",
                //  update only the below values
                m => m.CompanyName,
                m => m.CompanyAddress,
                m => m.CompanyWebsite,
                m => m.CompanyAbout))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}


/*
    Entity States

    The database context keeps track of whether entities in memory are in sync with their 
    corresponding rows in the database. This tracking information determines what happens 
    when SaveChangesAsync is called. For example, when a new entity is passed to the 
    AddAsync method, that entity's state is set to Added. When SaveChangesAsync is called, 
    the database context issues a SQL INSERT command
 
 */