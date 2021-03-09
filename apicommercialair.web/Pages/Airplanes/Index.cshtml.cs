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
    public class IndexModel : PageModel
    {
        private readonly apicommercialair.data.CommercialairDbContext _context;

        public IndexModel(apicommercialair.data.CommercialairDbContext context)
        {
            _context = context;
        }

        public IList<Aircraft> Aircraft { get;set; }

        public async Task OnGetAsync()
        {
            Aircraft = await _context.Aircraft
                .Include(a => a.Manufacturer).ToListAsync();
        }
    }
}
