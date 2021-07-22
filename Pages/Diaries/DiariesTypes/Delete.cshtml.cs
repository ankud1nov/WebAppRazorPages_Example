using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Diaries.DiariesTypes
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.WebAppDiaryContext _context;

        public DeleteModel(WebApp.Data.WebAppDiaryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiaryType DiaryType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiaryType = await _context.DiariesTypes.FirstOrDefaultAsync(m => m.ID == id);

            if (DiaryType == null)
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

            DiaryType = await _context.DiariesTypes.FindAsync(id);

            if (DiaryType != null)
            {
                _context.DiariesTypes.Remove(DiaryType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
