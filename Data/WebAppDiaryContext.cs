using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
