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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.WebAppDiaryContext _context;

        public DetailsModel(WebApp.Data.WebAppDiaryContext context)
        {
            _context = context;
        }

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
    }
}
