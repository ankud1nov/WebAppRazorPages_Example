using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Diaries.DiariesTypes
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Data.WebAppDiaryContext _context;

        public EditModel(WebApp.Data.WebAppDiaryContext context)
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

            DiaryType = await _context.DiaryType.FirstOrDefaultAsync(m => m.ID == id);

            if (DiaryType == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DiaryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryTypeExists(DiaryType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiaryTypeExists(int id)
        {
            return _context.DiaryType.Any(e => e.ID == id);
        }
    }
}
