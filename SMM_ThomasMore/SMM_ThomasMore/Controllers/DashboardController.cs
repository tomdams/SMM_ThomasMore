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

    public Dashboard GetDashboard(User u, Deelplatform platform)
    {
      return mgr.GetDashboard(u, platform);
    }

    public Grafiek UpdateGrafiek(Grafiek g)
    {
      return mgr.updateGrafiek(g);
    }

    public void AddGrafiek(Dashboard d, Grafiek g)
    {
      mgr.addGrafiek(d, g);
    }

    public Grafiek GetGrafiek(int id)
    {
      return mgr.GetGrafiek(id);
    }

    public void RemoveGrafiek(int id)
    {
      mgr.RemoveGrafiek(id);
    }

    public void UpdateGrafieken()
    {
      mgr.updateGrafieken();
    }

  }
}