using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.DAL;

namespace SMM_ThomasMore.BL
{
  public class DashboardManager : IDashboardManager
  {
    private IDashboardRepository repo;

    public DashboardManager()
    {
      repo = new DashboardRepository();
    }

    public Dashboard GetDashboard(User u)
    {
            repo.GetGrafieken().ToList();
      return repo.GetDashboard(u);
    }
  }
}
