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

        public void addPersoon(Persoon p, int platformid)
        {
          p.grafieken = basisGrafieken(p);
          ctx.Personen.Add(p);
          Deelplatform deelplatform = ctx.Deelplatformen.Find(platformid);
          deelplatform.elements.Add(p);
          p.Deelplatform = deelplatform;
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

        public Element getElement(int element_Id)
        {
            return ctx.Elements.Find(element_Id);
        }
        public IEnumerable<Element> getElements(int platform_id)
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

    private List<Grafiek> basisGrafieken(Element e)
    {
      List<Grafiek> grafieken = new List<Grafiek>();
      Grafiek g1 = new Grafiek()
      {
        titel = "Aantal vermeldingen " + e.naam,
        plaats = 3,
        kruising = false,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "",
        y_as_beschrijving = "",

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
        kruising = false,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "",
        y_as_beschrijving = "",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.SENTIMENT,
        grafiekType = GrafiekType.STAAF,
        element = e 
      };

      Grafiek g3 = new Grafiek()
      {
        titel = "Mannen/Vrouwen over " + e.naam,
        plaats = 3,
        kruising = false,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "",
        y_as_beschrijving = "",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.GESLACHT,
        grafiekType = GrafiekType.TAART,
        element = e
      };

      grafieken.Add(g1);
      grafieken.Add(g2);
      grafieken.Add(g3);
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

    public Element getElement(string naam, int platform_id)
    {
      List<Persoon> personen = new List<Persoon>();
      foreach(Persoon p in ctx.Personen)
      {
        if (p.naam.ToLower().Equals(naam.ToLower()))
        {
          personen.Add(p);
        }
      }

      foreach(Persoon p in personen)
      {
        if(p.Deelplatform.id == platform_id)
        {
          return p;
        }
      }

      List<Organisatie> organisaties = new List<Organisatie>();
      foreach (Organisatie o in ctx.Organisaties)
      {
        if (o.naam.ToLower().Equals(naam.ToLower()))
        {
          organisaties.Add(o);
        }
      }

      foreach (Organisatie o in organisaties)
      {
        if (o.Deelplatform.id == platform_id)
        {
          return o;
        }
      }

      List<Thema> themas = new List<Thema>();
      foreach (Thema t in ctx.Themas)
      {
        if (t.naam.ToLower().Equals(naam.ToLower()))
        {
          themas.Add(t);
        }
      }

      foreach (Thema t in themas)
      {
        if (t.Deelplatform.id == platform_id)
        {
          return t;
        }
      }

      return null;
    }
  }
}
