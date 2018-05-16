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
      Element e = ctx.Elements.Find(g.element.element_id);
      if(g.dashboard is null)
      {
        Grafiek graph = new Grafiek();
        graph.beginDate = g.beginDate;
        graph.eindDate = g.eindDate;
        graph.titel = g.titel;
        graph.grafiekOnderwerp = g.grafiekOnderwerp;
        graph.grafiekType = g.grafiekType;
        graph.leeftijd = g.leeftijd;
        graph.opleiding = g.opleiding;
        graph.polariteit = g.polariteit;
        graph.plaats = g.plaats;
        graph.x_as = g.x_as;
        graph.y_as = g.y_as;
        graph.x_as_beschrijving = g.x_as_beschrijving;
        graph.y_as_beschrijving = g.y_as_beschrijving;
        graph.dashboard = dashboard;
        dashboard.grafieken.Add(graph);
        graph.element = e;
        e.grafieken.Add(graph);
      }
      else if (!(ctx.Grafieken.Find(g.id) is null))
      {
        Grafiek graph = ctx.Grafieken.Find(g.id);
        graph.beginDate = g.beginDate;
        graph.eindDate = g.eindDate;
        graph.titel = g.titel;
        graph.grafiekOnderwerp = g.grafiekOnderwerp;
        graph.grafiekType = g.grafiekType;
        graph.leeftijd = g.leeftijd;
        graph.opleiding = g.opleiding;
        graph.polariteit = g.polariteit;
        graph.plaats = g.plaats;
        graph.x_as = g.x_as;
        graph.y_as = g.y_as;
        graph.x_as_beschrijving = g.x_as_beschrijving;
        graph.y_as_beschrijving = g.y_as_beschrijving;
      }
      else
      {
        dashboard.grafieken.Add(g);
        ctx.Grafieken.Add(g);
      }
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

    public void RemoveGrafiek(int id)
    {
      ctx.Grafieken.Remove(ctx.Grafieken.Find(id));
      ctx.SaveChanges();
    }

    public void setElement(int grafiekId, int elementId)
    {
      Grafiek graph = ctx.Grafieken.Find(grafiekId);
      Element e = ctx.Elements.Find(elementId);
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
