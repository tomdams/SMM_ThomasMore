using SC.BL.Domain.SocialeMedia;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.DAL
{
  public interface IDashboardRepository
  {
    Dashboard GetDashboard(User u, Deelplatform platform);
    Grafiek GetGrafiek(int id);
    IEnumerable<Grafiek> GetGrafieken();
    void addGrafiek(Dashboard d, Grafiek g);
    void updateGrafiek(string x_as, string y_as, int grafiek_id);
    IEnumerable<Message> GetMessages();
    void setElement(int grafiekid, int elementid);
    void RemoveGrafiek(int id);
  }
}
