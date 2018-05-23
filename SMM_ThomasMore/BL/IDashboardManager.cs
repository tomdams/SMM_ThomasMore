using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.BL
{
  public interface IDashboardManager
  {
    Dashboard GetDashboard(User u, Deelplatform platform);
    void addGrafiek(Dashboard d, Grafiek g);
    Grafiek updateGrafiek(Grafiek g);
    void updateGrafieken(int platformId);
    Grafiek GetGrafiek(int id);
    void RemoveGrafiek(int id, int platform_Id);
    Dashboard GetAdminDashboard(int platformId);
    List<Grafiek> GetGrafieken(Dashboard dashboard);
    }
}
