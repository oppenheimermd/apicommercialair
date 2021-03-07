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
    public class IndexModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public IndexModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturers.ToListAsync();
        }
    }
}
