using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppDiaryContext : DbContext
    {
        public WebAppDiaryContext (DbContextOptions<WebAppDiaryContext> options)
            : base(options)
        {
        }
        public DbSet<DiaryType> DiaryType { get; set; }

        public DbSet<Diary> Diary { get; set; }

        
    }
}
