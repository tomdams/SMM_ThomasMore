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
    Dashboard GetDashboard(User u);
    void addGrafiek(Dashboard d, Grafiek g);
    Grafiek updateGrafiek(Grafiek g);
    void updateGrafieken();
  }
}
