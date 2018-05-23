using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.DAL;
using SC.BL.Domain.User;
using SC.BL.Domain.SocialeMedia;
using System.Globalization;
using SC.BL;

namespace SMM_ThomasMore.BL
{
  public class DashboardManager : IDashboardManager
  {
    private IDashboardRepository repo;

    public DashboardManager()
    {
      repo = new DashboardRepository();
    }

    public void addGrafiek(Dashboard d, Grafiek g)
    {
      repo.addGrafiek(d, g);
    }

    public Dashboard GetDashboard(User u, Deelplatform platform)
    {
      repo.GetGrafieken().ToList();
      return repo.GetDashboard(u, platform);
    }

    public void updateGrafieken(int platformId)
    {
      foreach (Grafiek g in repo.GetGrafieken())
      {
        if(g.elements.First().Deelplatform.id == platformId)
        {
          Grafiek graph = updateGrafiek(repo.GetGrafiek(g.id));
          repo.updateGrafiek(graph.x_as, graph.y_as, graph.id);
        }
      }
    }

    public Grafiek updateGrafiek(Grafiek g)
    {
      string y_as = "";
      string y_as1 = "";
      string y_as2 = "";
      string y_as3 = "";
      string y_as4 = "";
      string x_as = "";

      if (g.elements.Count > 1)
      {
        int count = 0;
        string temporaryString = "";
        List<Element> elements = g.elements.ToList();
        elements.Sort();
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.GESLACHT))
        {
          foreach(Element e in elements)
          {
            temporaryString = countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, Geslacht.Man, g.polariteit, g.opleiding) + ", " +
            "" + countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, Geslacht.Vrouw, g.polariteit, g.opleiding);

            switch (count)
            {
              case 0: y_as = temporaryString; break;
              case 1: y_as1 = temporaryString; break;
              case 2: y_as2 = temporaryString; break;
              case 3: y_as3 = temporaryString; break;
              case 4: y_as4 = temporaryString; break;
            }
            count++;
          }
          x_as = "Man, Vrouw";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.DATUM))
        {
          double days = (g.eindDate - g.beginDate).TotalDays;
          foreach (Element e in elements)
          {
            for (int i = 0; i < 5; i++)
            {
              temporaryString += countVermeldingen(e, g.beginDate.AddDays(i * (days / 5)), g.beginDate.AddDays((i + 1) * (days / 5)), g.leeftijd, g.geslacht, g.polariteit, g.opleiding) + ", ";
            }
            switch (count)
            {
              case 0: y_as = temporaryString; break;
              case 1: y_as1 = temporaryString; break;
              case 2: y_as2 = temporaryString; break;
              case 3: y_as3 = temporaryString; break;
              case 4: y_as4 = temporaryString; break;
            }
            count++;
            temporaryString = "";
          }
          for (int i = 0; i < 5; i++)
          {
            x_as += g.beginDate.AddDays(i * (days / 5)).ToShortDateString() + " - " + g.beginDate.AddDays((i + 1) * (days / 5)).ToShortDateString() + ", ";
          }
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.SENTIMENT))
        {
          foreach (Element e in elements)
          {
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.POSITIEF, g.opleiding) + ", ";
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.NEGATIEF, g.opleiding) + ", ";
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.NEUTRAAL, g.opleiding);

            switch (count)
            {
              case 0: y_as = temporaryString; break;
              case 1: y_as1 = temporaryString; break;
              case 2: y_as2 = temporaryString; break;
              case 3: y_as3 = temporaryString; break;
              case 4: y_as4 = temporaryString; break;
            }
            count++;
            temporaryString = "";
          }
          x_as = "Positief, Negatief, Neutraal";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.LEEFTIJD))
        {
          foreach (Element e in elements)
          {
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, "25+", g.geslacht, g.polariteit, g.opleiding) + ", ";
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, "25-", g.geslacht, g.polariteit, g.opleiding) + ", ";
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, "", g.geslacht, g.polariteit, g.opleiding);

            switch (count)
            {
              case 0: y_as = temporaryString; break;
              case 1: y_as1 = temporaryString; break;
              case 2: y_as2 = temporaryString; break;
              case 3: y_as3 = temporaryString; break;
              case 4: y_as4 = temporaryString; break;
            }
            count++;
            temporaryString = "";
          }
          x_as = "25+, 25-, Onbekend";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.OPLEIDING))
        {
          foreach (Element e in elements)
          {
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, g.geslacht, g.polariteit, "+") + ", ";
            temporaryString += countVermeldingen(e, g.beginDate, g.eindDate, g.leeftijd, g.geslacht, g.polariteit, "-");

            switch (count)
            {
              case 0: y_as = temporaryString; break;
              case 1: y_as1 = temporaryString; break;
              case 2: y_as2 = temporaryString; break;
              case 3: y_as3 = temporaryString; break;
              case 4: y_as4 = temporaryString; break;
            }
            count++;
            temporaryString = "";
          } 
          x_as = "+, -";
        }
      }
      else
      {
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.GESLACHT))
        {
          y_as = countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, Geslacht.Man, g.polariteit, g.opleiding) + ", " +
            "" + countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, Geslacht.Vrouw, g.polariteit, g.opleiding);
          x_as = "Man, Vrouw";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.DATUM))
        {
          double days = (g.eindDate - g.beginDate).TotalDays;
          for (int i = 0; i < 5; i++)
          {
            y_as += countVermeldingen(g.elements.First(), g.beginDate.AddDays(i * (days / 5)), g.beginDate.AddDays((i + 1) * (days / 5)), g.leeftijd, g.geslacht, g.polariteit, g.opleiding) + ", ";
            x_as += g.beginDate.AddDays(i * (days / 5)).ToShortDateString() + " - " + g.beginDate.AddDays((i + 1) * (days / 5)).ToShortDateString() + ", ";
          }
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.SENTIMENT))
        {
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.POSITIEF, g.opleiding) + ", ";
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.NEGATIEF, g.opleiding) + ", ";
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, g.geslacht, Polariteit.NEUTRAAL, g.opleiding);
          x_as = "Positief, Negatief, Neutraal";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.LEEFTIJD))
        {
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, "25+", g.geslacht, g.polariteit, g.opleiding) + ", ";
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, "25-", g.geslacht, g.polariteit, g.opleiding) + ", ";
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, "", g.geslacht, g.polariteit, g.opleiding);
          x_as = "25+, 25-, Onbekend";
        }
        if (g.grafiekOnderwerp.Equals(GrafiekOnderwerp.OPLEIDING))
        {
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, g.geslacht, g.polariteit, "+") + ", ";
          y_as += countVermeldingen(g.elements.First(), g.beginDate, g.eindDate, g.leeftijd, g.geslacht, g.polariteit, "-");
          x_as = "+, -";
        }
        
      }
      g.x_as = x_as;
      g.y_as = y_as;
      g.y_as1 = y_as1;
      g.y_as2 = y_as2;
      g.y_as3 = y_as3;
      g.y_as4 = y_as4;
      g.y_as_beschrijving = "Aantal Vermeldingen";
      g.x_as_beschrijving = g.grafiekOnderwerp.ToString();
      return g;
    }

    private int countVermeldingen(Element e, DateTime startDate, DateTime endDate, string leeftijd, Geslacht? geslacht, Polariteit? polariteit, string opleiding)
    {
      int aantalVermeldingen = 0;

      foreach (Message m in repo.GetMessages())
      {
        if (m.date > startDate && m.date < endDate)
        {
          if ((leeftijd is null) || (leeftijd.Equals(m.age)))
          {
            if ((geslacht is null) || (m.geslacht.Equals(geslacht)))
            {
              if ((opleiding is null) || (opleiding.Equals(m.education)))
              {
                Polariteit? p = null;
                if (m.sentiment.Length > 2)
                {
                  string data = m.sentiment;
                  string[] stringSeparators = new string[] { ",\r\n " };
                  data = data.Trim().Remove(0, 5).Remove(data.Length - 8, 3);
                  string[] gesplitsteData = data.Split(stringSeparators, StringSplitOptions.None);
                  List<Double> lijst = gesplitsteData.Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
                  double polariteitWaarde = lijst.First();

                  if (polariteitWaarde > 0)
                  {
                    p = Polariteit.POSITIEF;
                  }
                  else if (polariteitWaarde < 0)
                  {
                    p = Polariteit.NEGATIEF;
                  }
                  else
                  {
                    p = Polariteit.NEUTRAAL;
                  }
                }

                if ((polariteit is null) || (polariteit.Equals(p)))
                {
                  if (m.persons.ToLower().Contains(e.naam.ToLower()))
                  {
                    aantalVermeldingen++;
                  }
                  else
                  {
                    if (m.words.ToLower().Contains(e.naam.ToLower()))
                    {
                      aantalVermeldingen++;
                    }
                  }
                }
              }
            }
          }
        }
      }
      return aantalVermeldingen;
    }

    public Grafiek GetGrafiek(int id)
    {
      return repo.GetGrafiek(id);
    }

    public void RemoveGrafiek(int id, int platform_Id)
    {
      repo.RemoveGrafiek(id, platform_Id);
    }

    public Dashboard GetAdminDashboard(int platformId)
    {
      return repo.GetAdminDashboard(platformId);
    }

        public List<Grafiek> GetGrafieken(Dashboard dashboard)
        {
            List<Grafiek> grafieken = new List<Grafiek>();
            foreach (Grafiek g in repo.GetGrafieken().ToList()) {
                if (g.dashboards.Contains(dashboard)) {
                    grafieken.Add(g);
                }
            }
            return grafieken;
        
        }
    }
}

