using System.Web;
using System.Web.Mvc;

namespace _FilRouge.Web_Quizz
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
