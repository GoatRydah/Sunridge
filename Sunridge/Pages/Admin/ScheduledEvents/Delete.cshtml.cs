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
    public class DeleteModel : PageModel
    {
        private readonly Sunridge.Data.ApplicationDbContext _context;

        public DeleteModel(Sunridge.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScheduledEvent ScheduledEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScheduledEvent = await _context.ScheduledEvent.FirstOrDefaultAsync(m => m.ID == id);

            if (ScheduledEvent == null)
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

            ScheduledEvent = await _context.ScheduledEvent.FindAsync(id);

            if (ScheduledEvent != null)
            {
                _context.ScheduledEvent.Remove(ScheduledEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
