using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.DAL.EF;

namespace SMM_ThomasMore.DAL
{
  public class DashboardRepository : IDashboardRepository
  {
    private SMMDbContext ctx;

    public DashboardRepository()

    {
      ctx = new SMMDbContext();
      ctx.Database.Initialize(false);
    }

    public Dashboard GetDashboard(User u)
    {
      foreach(Dashboard d in ctx.Dashboards.ToList())
      {
        if (d.user.user_id == u.user_id)
        {
          return d;
        }
      }
      return null;
    }

        public IEnumerable<Grafiek> GetGrafieken()
        {
            return ctx.Grafieken.ToList<Grafiek>();
        }

  }
    

}
