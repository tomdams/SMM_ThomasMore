using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;

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
      Element e = ctx.Elements.Find(ai.element.element_id);
      User u = ctx.Users.Find(ai.user.user_id);
      e.alertInstellingen.Add(ai);
      u.alertInstellingen.Add(ai);
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
      Organisatie o = getOrganisatie(p.organisation);

      if (o is null)
      {
        o = new Organisatie() { naam = p.organisation, Deelplatform = p.Deelplatform, personen = new List<Persoon>() { p } };
        ctx.Elements.Add(o);
      }
      else
      {
        o.personen.Add(p);
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
      foreach (Organisatie o in ctx.Organisaties)
      {
        elements.Add(o);
      }
      foreach (Thema t in ctx.Themas)
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
        x_as = "",
        y_as = "",
        x_as_beschrijving = "",
        y_as_beschrijving = "",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM_PER_DAG,
        grafiekType = GrafiekType.LIJN,
      };

      Grafiek g2 = new Grafiek()
      {
        titel = "Polariteit " + e.naam,
        plaats = 3,
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
      };

      Grafiek g3 = new Grafiek()
      {
        titel = "Mannen/Vrouwen over " + e.naam,
        plaats = 3,
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
      };

      g1.elements.Add(e);
      g2.elements.Add(e);
      g3.elements.Add(e);
      grafieken.Add(g1);
      grafieken.Add(g2);
      grafieken.Add(g3);
      return grafieken;
    }

    public Element getElement(string naam, int platform_id)
    {
      List<Persoon> personen = new List<Persoon>();
      foreach (Persoon p in ctx.Personen)
      {
        if (p.naam.ToLower().Equals(naam.ToLower()))
        {
          personen.Add(p);
        }
      }

      foreach (Persoon p in personen)
      {
        if (p.Deelplatform.id == platform_id)
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

    public Organisatie getOrganisatie(string organisation)
    {
      Organisatie o = null;
      foreach (Organisatie organisatie in ctx.Organisaties)
      {
        if (organisatie.naam.Equals(organisation))
        {
          o = organisatie;
        }
      }
      return o;
    }

    public void addOrganisatie(Organisatie o, int platformid)
    {
      ctx.Organisaties.Add(o);
      Deelplatform deelplatform = ctx.Deelplatformen.Find(platformid);
      deelplatform.elements.Add(o);
      o.Deelplatform = deelplatform;
      ctx.SaveChanges();
    }

    public void addThema(Thema e, int platform_id)
    {
      e.grafieken = basisGrafieken(e);
      ctx.Themas.Add(e);
      Deelplatform deelplatform = ctx.Deelplatformen.Find(platform_id);
      deelplatform.elements.Add(e);
      e.Deelplatform = deelplatform;
      ctx.SaveChanges();
    }

    public void updateElement(Element element, int element_id, int platformid)
    {
      if (element.GetType().ToString().ToLower().Contains("thema"))
      {
        Thema nieuw = (Thema)element;
        Thema e = (Thema)getElement(element_id);
        e.naam = nieuw.naam;
        e.keywords = nieuw.keywords;
        ctx.SaveChanges();
      }
      else if (element.GetType().ToString().ToLower().Contains("organisatie"))
      {
        Organisatie nieuw = (Organisatie)element;
        Organisatie e = (Organisatie)getElement(element_id);

        e.naam = nieuw.naam;
        e.twitter = nieuw.twitter;
        e.facebook = nieuw.facebook;
        e.gemeente = nieuw.gemeente;
        ctx.SaveChanges();
      }
      else if (element.GetType().ToString().ToLower().Contains("persoon"))
      {
        Persoon nieuw = (Persoon)element;
        Persoon e = (Persoon)getElement(element_id);
        bool bestaat = false;

        if (nieuw.organisation != null)
        {
          foreach (var organisatie in ctx.Organisaties)
          {
            if (organisatie.naam.ToLower().Equals(nieuw.organisation.ToLower()))
            {
              bestaat = true;
            }
          }
        }


        e.naam = nieuw.naam;
        e.geboorteDatum = nieuw.geboorteDatum;
        e.geslacht = nieuw.geslacht;
        e.twitter = nieuw.twitter;
        e.facebook = nieuw.facebook;
        e.town = nieuw.town;
        e.postal_code = nieuw.postal_code;
        e.district = nieuw.district;
        e.organisation = nieuw.organisation;
        if (nieuw.geboorteDatum == new DateTime(1, 1, 1))
        {
          e.geboorteDatum = null;
        }
        if (!bestaat)
        {
          Organisatie o = new Organisatie() { naam = nieuw.organisation, Deelplatform = ctx.Deelplatformen.Find(platformid), personen = new List<Persoon>() };
          o.personen.Add(e);
          ctx.Organisaties.Add(o);
        }

        ctx.SaveChanges();

      }
    }

    public void deleteElement(int element_id)
    {
      Element e = (getElement(element_id)); 

      if (e.GetType().ToString().ToLower().Contains("thema"))
      {
        Thema t = (Thema)e;
        ctx.Keywords.RemoveRange(t.keywords);
        ctx.Themas.Remove((Thema)e);
      }
      else if (e.GetType().ToString().ToLower().Contains("organisatie"))
      {
        Organisatie o = (Organisatie)e;
        foreach (var persoon in o.personen)
        {
          persoon.organisation = null;
          persoon.organisatie = null;
        }
        ctx.Organisaties.Remove(o);
      }
      else if (e.GetType().ToString().ToLower().Contains("persoon"))
      {
        Persoon p = (Persoon)e;
        ctx.Personen.Remove(p);
      }
      ctx.SaveChanges();
    }
        public void addActiviteit(User u, string message)
        {
            Activiteit a = new Activiteit()
            {
                user_id = u.user_id,
                beschrijving = message,
                datum = DateTime.Now
            };
            ctx.Activiteiten.Add(a);
            ctx.SaveChanges();
        }
    }
}
