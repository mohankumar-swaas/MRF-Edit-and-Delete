using System.Web;
using System.Web.Mvc;

namespace MRF_Edit_and_Delete
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
