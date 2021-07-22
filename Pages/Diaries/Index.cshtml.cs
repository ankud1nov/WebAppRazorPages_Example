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
    public class IndexModel : PageModel
    {
        private readonly WebAppDiaryContext _context;

        public IndexModel(WebAppDiaryContext context)
        {
            _context = context;
        }

        public IList<Diary> Diary { get;set; }
        public IList<DiaryType> DiaryType { get; set; }

        public async Task OnGetAsync()
        {
            Diary = await _context.Diaries.ToListAsync();
            DiaryType = await _context.DiariesTypes.ToListAsync();
        }
    }
}
