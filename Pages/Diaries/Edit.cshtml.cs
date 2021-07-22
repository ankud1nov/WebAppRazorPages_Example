using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.DBFunction;

namespace WebApp.Pages.Diaries
{
    public class EditModel : PageModel
    {
        private readonly WebAppDiaryContext _context;
        public SelectList _DiaryType;

        public EditModel(WebAppDiaryContext context)
        {
            _context = context;
            _DiaryType = new SelectList(_context.DiariesTypes.ToList(), "ID", "Type");
        }

        [BindProperty]
        public Diary Diary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diary = await _context.Diaries.FirstOrDefaultAsync(m => m.ID == id);

            if (Diary == null)
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

            Diary.DiaryType = Gets.GetDiaryType(Diary.DiaryType.ID, _context);

            _context.Attach(Diary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryExists(Diary.ID))
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

        private bool DiaryExists(int id)
        {
            return _context.Diaries.Any(e => e.ID == id);
        }
    }
}
