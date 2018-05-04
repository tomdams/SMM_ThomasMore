using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
