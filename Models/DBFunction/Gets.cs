using System.Linq;
using WebApp.Data;

namespace WebApp.Models.DBFunction
{
    public class Gets
    {
        public static DiaryType GetDiaryType(int ID, WebAppDiaryContext context)
        {
            return context.DiaryType.Where(x => x.ID == ID).SingleOrDefault();
        }
        public static DiaryType GetDiaryType(string type, WebAppDiaryContext context)
        {
            return context.DiaryType.Where(x => x.Type == type).SingleOrDefault();
        }
    }
}
