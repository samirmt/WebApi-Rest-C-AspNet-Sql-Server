using System.Web;
using System.Web.Mvc;

namespace WebApi_Rest_C_AspNet_Sql_Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
