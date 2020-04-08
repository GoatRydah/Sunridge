using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sunridge.Data;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.ScheduledEvents
{
    public class IndexModel : PageModel
    {
        private readonly Sunridge.Data.ApplicationDbContext _context;

        public IndexModel(Sunridge.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ScheduledEvent> ScheduledEvent { get;set; }

        public async Task OnGetAsync()
        {
            ScheduledEvent = await _context.ScheduledEvent.ToListAsync();
        }
    }
}
