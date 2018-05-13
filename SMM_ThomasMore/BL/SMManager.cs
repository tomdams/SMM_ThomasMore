using Newtonsoft.Json;
using SC.BL.Domain;
using SC.BL.Domain.SocialeMedia;
using SC.BL.Domain.User;
using SC.DAL;
using SMM_ThomasMore.BL;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC.BL
{
  public class SMManager : ISMManager
  {
        private ISMRepository repo;
        private IElementRepository elementrepo;
        private IElementManager em;
        private readonly int MINIMUM = 10;
        private static DateTime lastRead = new DateTime(2018, 04, 25);
        private DateTime today = new DateTime(2018, 04, 29);

    public object UserController { get; private set; }

    public void checkTrending()
        {
            //elements ophalen
            elementrepo = new ElementRepository();
            List<Element> elements = elementrepo.getElements().ToList();

            foreach (Element e in elements)
            {
                if (checkTrending(e))
                {
                    em.genereerAlerts(e);
                }
            }
        }

        public bool checkTrending(Element e)
        {
            //tijdspanne vermeldingen veranderen
            int vermeldingenVandaag = countVermeldingen(e, today.AddDays(-1), today);

            if (vermeldingenVandaag > MINIMUM)
            {
                //gemiddelde van de laatste 3 dagen berekenen
                double gemiddeldeVermeldingen = 0;
                string history = "";

                for (int i = 1; i < 4; i++)
                {
                    gemiddeldeVermeldingen += countVermeldingen(e, today.AddDays(0 - (i + 1)), today.AddDays(0 - i));
                    history += e.naam + " dag(en) geleden " + i + ": " + countVermeldingen(e, today.AddDays(0 - (i + 1)), today.AddDays(0 - i)) + "\n";
                }
                gemiddeldeVermeldingen /= 3;

                if (vermeldingenVandaag > (gemiddeldeVermeldingen * 1.15))
                {
          /*
          System.Diagnostics.Debug.WriteLine(e.naam + " is trending");
          System.Diagnostics.Debug.WriteLine(e.naam + " vermeldingen vandaag " + vermeldingenVandaag);
          System.Diagnostics.Debug.WriteLine(e.naam + " 1 dag geleden: " + countVermeldingen(e, today.AddDays(0 - (2)), today.AddDays(-1)));
          System.Diagnostics.Debug.WriteLine(e.naam + " 2 dag geleden: " + countVermeldingen(e, today.AddDays(0 - (3)), today.AddDays(-2)));
          System.Diagnostics.Debug.WriteLine(e.naam + " 3 dag geleden: " + countVermeldingen(e, today.AddDays(0 - (4)), today.AddDays(-3)));
          */
          return true;
                }
            }
            return false;
        }

        public void readMessages()
    {
            //repo maken
            repo = new SMRepository();
            em = new ElementManager();

            string json = "";
            using (var client = new System.Net.Http.HttpClient())
            {
                var uri = "https://kdg.textgain.com/query";
                var httpRequest = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, uri);
                var content = "{ \"since\":\"" + lastRead.ToString("dd MMM yyyy HH:mm:ss") + "\" }";
                httpRequest.Content = new System.Net.Http.StringContent(content, Encoding.UTF8, "application/json");
                httpRequest.Headers.Add("X-API-Key", "aEN3K6VJPEoh3sMp9ZVA73kkr");
                httpRequest.Headers.Add("Accept", "application/json; charset=utf-8");

                System.Net.Http.HttpResponseMessage response = client.SendAsync(httpRequest).Result;
                if (response.IsSuccessStatusCode)
                {
                    json = response.Content.ReadAsStringAsync().Result;
                }
            };

            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                DateTime date = item.date;
                Message m = new Message();
                m.id = item.id;
                m.source = item.source;
                m.geo = item.geo.ToString();
                m.mentions = item.mentions.ToString();
                m.retweet = item.retweet;
                m.date = date;
                m.words = item.words.ToString();
                m.sentiment = item.sentiment.ToString();
                m.hashtags = item.hashtags.ToString();
                m.urls = item.urls.ToString();
                m.themas = item.themes.ToString();
                m.persons = item.persons.ToString();
                m.age = item.profile.age;
                if (item.profile.gender.ToString().ToLower().Equals("m"))
                {
                    m.geslacht = Geslacht.Man;
                }
                else
                {
                    m.geslacht = Geslacht.Vrouw;
                }
                m.education = item.profile.education;
                m.personality = item.profile.personality;
                m.language = item.profile.language;

                repo.add(m);
            }

            checkTrending();
            //Commentaar weghalen
            lastRead = DateTime.Now;
        }

    private int countVermeldingen(Element e, DateTime startDate, DateTime endDate)
    {
      /*
            int aantalVermeldingen = 0;

            foreach (Message m in repo.getMessages())
            {
                if (m.date > startDate && m.date < endDate)
                {
                    if (m.persons.ToLower().Contains(e.naam.ToLower()))
                    {
                        aantalVermeldingen++;
                    }
                    else if (m.words.ToLower().Contains(e.naam.ToLower()))
                    {
                        aantalVermeldingen++;
                    }
                    else if (e.GetType() == typeof(Persoon) || e.GetType() == typeof(Organisatie))
                    {
                        aantalVermeldingen++;
                    }
                }
            }
            return aantalVermeldingen;
            */

      int aantalVermeldingen = 0;

      foreach (Message m in repo.getMessages())
      {
        if (m.date > startDate && m.date < endDate)
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
      return aantalVermeldingen;
    }           
            }          
}