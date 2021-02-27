using System.Web;
using System.Web.Mvc;

namespace PassionProject_Barbershop_n01416375
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
