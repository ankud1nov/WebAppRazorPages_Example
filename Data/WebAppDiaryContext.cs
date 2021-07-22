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
        public DbSet<DiaryType> DiariesTypes { get; set; }
        public DbSet<Diary> Diaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryType>().ToTable("DiaryType");
            modelBuilder.Entity<Diary>().ToTable("Diary");
        }
    }
}
