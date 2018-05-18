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
      List<Element> elements = new List<Element>();
      foreach(Element e in ctx.Elements)
      {
        foreach(Element e2 in elements)
        {
          if(e.element_id == e2.element_id)
          {
            elements.Add(e);
          }
        }
      }

      //Grafiek van een element
      if(g.dashboards.Count == 0)
      {
        Grafiek graph = new Grafiek();
        graph.beginDate = g.beginDate;
        graph.eindDate = g.eindDate;
        graph.titel = g.titel;
        graph.kruising = g.kruising;
        graph.grafiekOnderwerp = g.grafiekOnderwerp;
        graph.grafiekType = g.grafiekType;
        graph.leeftijd = g.leeftijd;
        graph.opleiding = g.opleiding;
        graph.polariteit = g.polariteit;
        graph.plaats = g.plaats;
        graph.x_as = g.x_as;
        graph.y_as = g.y_as;
        graph.y_as1 = g.y_as1;
        graph.y_as2 = g.y_as2;
        graph.y_as3 = g.y_as3;
        graph.y_as4 = g.y_as4;
        graph.x_as_beschrijving = g.x_as_beschrijving;
        graph.y_as_beschrijving = g.y_as_beschrijving;
        graph.dashboards.Add(dashboard);
        dashboard.grafieken.Add(graph);
        foreach(Element e in elements)
        {
          graph.elements.Add(e);
          e.grafieken.Add(graph);
        }
        if (dashboard.adminDashboard)
        {
          foreach (Dashboard dboard in ctx.Dashboards)
          {
            if (dboard.deelplatform.id == dashboard.deelplatform.id && !(dboard.adminDashboard))
            {
              dboard.grafieken.Add(graph);
              graph.dashboards.Add(dboard);
            }
          }
        }
      }
      //Grafiek bestaat al
      else if (!(ctx.Grafieken.Find(g.id) is null))
      {
        if (!dashboard.user.type.Equals(UserType.ADMIN))
        {
          bool adminGrafiek = false;
          foreach (Dashboard dboard in g.dashboards)
          {
            if (dboard.adminDashboard)
            {
              adminGrafiek = true;
            }
          }

          if (adminGrafiek)
          {
            dashboard.grafieken.Remove(ctx.Grafieken.Find(g.id));
            ctx.Grafieken.Find(g.id).dashboards.Remove(dashboard);

            Grafiek graph = new Grafiek();
            graph.beginDate = g.beginDate;
            graph.eindDate = g.eindDate;
            graph.titel = g.titel;
            graph.kruising = g.kruising;
            graph.grafiekOnderwerp = g.grafiekOnderwerp;
            graph.grafiekType = g.grafiekType;
            graph.leeftijd = g.leeftijd;
            graph.opleiding = g.opleiding;
            graph.polariteit = g.polariteit;
            graph.plaats = g.plaats;
            graph.x_as = g.x_as;
            graph.y_as = g.y_as;
            graph.y_as1 = g.y_as1;
            graph.y_as2 = g.y_as2;
            graph.y_as3 = g.y_as3;
            graph.y_as4 = g.y_as4;
            graph.x_as_beschrijving = g.x_as_beschrijving;
            graph.y_as_beschrijving = g.y_as_beschrijving;
            graph.dashboards.Add(dashboard);
            dashboard.grafieken.Add(graph);
            foreach(Element e in elements)
            {
              graph.elements.Add(e);
              e.grafieken.Add(graph);
            }
            dashboard.grafieken.Add(graph);
            graph.dashboards.Add(dashboard);

          }
        }
        else
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
        
      }
      //Nieuwe grafiek
      else
      {
        dashboard.grafieken.Add(g);
        g.dashboards.Add(dashboard);
        foreach(Element e in elements)
        {
          e.grafieken.Add(g);
        }  
        if (dashboard.adminDashboard)
        {
          foreach(Dashboard dboard in ctx.Dashboards)
          {
            if(dboard.deelplatform.id == dashboard.deelplatform.id && !(dboard.adminDashboard))
            {
              dboard.grafieken.Add(g);
              g.dashboards.Add(dboard);
            }
          }
        }
        ctx.Grafieken.Add(g);
      }
      ctx.SaveChanges();
    }

    public Dashboard GetAdminDashboard(int platformid)
    {
      foreach(Dashboard d in ctx.Deelplatformen.Find(platformid).dashboards)
      {
        if (d.adminDashboard)
        {
          return d;
        }
      }

      return null;
    }

    public Dashboard GetDashboard(User u, Deelplatform platform)
    {
      foreach (Dashboard d in ctx.Dashboards.ToList())
      {
        if (d.user.user_id == u.user_id && d.deelplatform.id == platform.id)
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

    public void RemoveGrafiek(int id, int dashboardId)
    {
      if (ctx.Dashboards.Find(dashboardId).adminDashboard)
      {
        ctx.Grafieken.Remove(ctx.Grafieken.Find(id));
      }
      else
      {
        Grafiek g = ctx.Grafieken.Find(id);
        Dashboard d = ctx.Dashboards.Find(dashboardId);
        g.dashboards.Remove(d);
        d.grafieken.Remove(g);
      }

      ctx.SaveChanges();

    }

    public void setElement(int grafiekId, int elementId)
    {
      Grafiek graph = ctx.Grafieken.Find(grafiekId);
      Element e = ctx.Elements.Find(elementId);
      graph.elements.Add(e);
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
