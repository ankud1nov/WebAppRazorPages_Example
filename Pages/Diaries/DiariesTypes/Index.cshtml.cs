using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Diaries.DiariesTypes
{
    public class IndexModel : PageModel
    {
        private readonly WebAppDiaryContext _context;

        public IndexModel(WebAppDiaryContext context)
        {
            _context = context;
        }

        public IList<DiaryType> DiaryType { get;set; }

        public async Task OnGetAsync()
        {
            DiaryType = await _context.DiariesTypes.ToListAsync();
        }
    }
}
