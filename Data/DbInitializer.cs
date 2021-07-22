using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebAppDiaryContext context)
        {
            if (context.Database.EnsureCreated())
            {
                var diariesTypes = new DiaryType[]
                {
                    new DiaryType{ID = 1, Type = "Встреча"},
                    new DiaryType{ID = 2, Type = "Дело"},
                    new DiaryType{ID = 3, Type = "Памятка"}
                };
                context.DiariesTypes.AddRange(diariesTypes);
                context.SaveChanges();
            }
        }
    }
}
