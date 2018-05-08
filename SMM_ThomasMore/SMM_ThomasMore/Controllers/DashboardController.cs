using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;

namespace SMM_ThomasMore.Controllers
{
  public class DashboardController
  {
    private IDashboardManager mgr;

    public DashboardController()
    {
      mgr = new DashboardManager();
    }

    public Dashboard GetDashboard(User u)
    {
      return mgr.GetDashboard(u);
    }

       
  }
}