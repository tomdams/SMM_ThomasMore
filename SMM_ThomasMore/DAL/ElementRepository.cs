using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;
using System;

namespace SMM_ThomasMore.DAL
{
  public class ElementRepository : IElementRepository
    {
        private SMMDbContext ctx;
        private DashboardRepository dashboardRepository;
        public ElementRepository()
        {
            ctx = new SMMDbContext();
            dashboardRepository = new DashboardRepository();
            ctx.Database.Initialize(false);
        }

        public void AddAI(AlertInstellingen ai)
        {
            ctx.AlertInstellingen.Add(ai);
            ctx.SaveChanges();
        }

        public void addPersoon(Persoon p)
    {
      p.grafieken = basisGrafieken(p);
      ctx.Personen.Add(p);
      foreach (var grafiek in p.grafieken)
      {
        ctx.Grafieken.Add(grafiek);
      }
      ctx.SaveChanges();
    }
        public void berekenPersoon(Persoon persoon)
        {


            //ctx.SaveChanges();
        }
        public IEnumerable<AlertInstellingen> getAIs()
        {
            return ctx.AlertInstellingen;
        }

        public Element getElement(int id)
        {
            foreach (Element e in ctx.Elements)
            {
                if (e.element_id == id)
                {
                    return e;
                }
            }

            return null;
        }
        public IEnumerable<Element> getElements()
        {
          List<Element> elements = new List<Element>();
          foreach (Persoon p in ctx.Personen)
          {
            elements.Add(p);
          }
          foreach(Organisatie o in ctx.Organisaties)
          {
            elements.Add(o);
          }
          foreach(Thema t in ctx.Themas)
          {
            elements.Add(t);
          }
          return elements;
        }

        public IEnumerable<Persoon> getPersonen()
        {
           return ctx.Personen;
        }
        public Persoon getPersoon(string naam)
        {
            Persoon p = null;
            var personen = ctx.Personen.Include("Grafieken");
            foreach (Persoon persoon in personen)
            {
                if (persoon.naam.Equals(naam))
                {
                    p = persoon;
                }
            }


      return p;
        }

        public User getUser(int id)
        {
            foreach (User u in ctx.Users)
            {
                if (u.user_id == id)
                {
                    return u;
                }
            }
            return null;
        }


        public void RemoveAI(AlertInstellingen ai)
        {
            ctx.AlertInstellingen.Remove(ai);
            ctx.SaveChanges();
        }

    public List<Grafiek> basisGrafieken(Element e)
    {
      List<Grafiek> grafieken = new List<Grafiek>();
      Grafiek g1 = new Grafiek()
      {
        titel = "Aantal vermeldingen " + e.naam,
        plaats = 3,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "Datum",
        y_as_beschrijving = "Aantal vermeldingen",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM,
        grafiekType = GrafiekType.LIJN,
        element = e
      };

      Grafiek g2 = new Grafiek()
      {
        titel = "Polariteit " + e.naam,
        plaats = 3,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "Datum",
        y_as_beschrijving = "Aantal vermeldingen",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM,
        grafiekType = GrafiekType.LIJN,
        element = e 
      };

      grafieken.Add(g1);
      //grafieken.Add(g2);
      return grafieken;
    }

    public void addOrganisatie(Organisatie o)
    {
      throw new NotImplementedException();
    }

    public void addThema(Thema t)
    {
      throw new NotImplementedException();
    }
  }
}
