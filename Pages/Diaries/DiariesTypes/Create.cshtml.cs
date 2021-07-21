using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Diaries.DiariesTypes
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.WebAppDiaryContext _context;

        public CreateModel(WebApp.Data.WebAppDiaryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DiaryType DiaryType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DiaryType.Add(DiaryType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
