using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Diaries
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.WebAppDiaryContext _context;

        public DeleteModel(WebApp.Data.WebAppDiaryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diary Diary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diary = await _context.Diary.FirstOrDefaultAsync(m => m.ID == id);

            if (Diary == null)
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

            Diary = await _context.Diary.FindAsync(id);

            if (Diary != null)
            {
                _context.Diary.Remove(Diary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
