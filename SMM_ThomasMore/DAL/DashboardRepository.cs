using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.DAL.EF;
using SC.BL.Domain.SocialeMedia;

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

    public void addGrafiek(Dashboard d, Grafiek g)
    {
      Dashboard dashboard = ctx.Dashboards.Find(d.id);
      dashboard.grafieken.Add(g);
      ctx.Grafieken.Add(g);
      ctx.SaveChanges();

    }

    public Dashboard GetDashboard(User u)
    {
      foreach (Dashboard d in ctx.Dashboards.ToList())
      {
        if (d.user.user_id == u.user_id)
        {
          return d;
        }
      }
      return null;
    }

    public Grafiek GetGrafiek(int id)
    {
      return ctx.Grafieken.Find(id);
    }

    public IEnumerable<Grafiek> GetGrafieken()
    {
      return ctx.Grafieken.ToList<Grafiek>();
    }

    public IEnumerable<Message> GetMessages()
    {
      return ctx.Messages.ToList();
    }

    public void setElement(Grafiek g)
    {
      Grafiek graph = ctx.Grafieken.Find(g.id);
      Element e = ctx.Elements.Find(163);
      graph.element = e;
      e.grafieken.Add(graph);
      ctx.SaveChanges();
    }

    public void updateGrafiek(string x_as, string y_as, int grafiek_id)
    {
      Grafiek g = ctx.Grafieken.Find(grafiek_id);
      g.x_as = x_as;
      g.y_as = y_as;
      ctx.SaveChanges();
    }
  }
}
