﻿using Newtonsoft.Json;
using SC.BL.Domain;
using SC.BL.Domain.SocialeMedia;
using SC.BL.Domain.User;
using SC.DAL;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SMM_ThomasMore.BL
{
    public class ElementManager : IElementManager
    {
        private IElementRepository repo;
        private IUserManager userMgr;
        private IUserRepository userRepo;
        private ISMRepository smRepo;
        private DateTime today = new DateTime(2018, 04, 29);

        public ElementManager()
        {
            repo = new ElementRepository();
            userMgr = new UserManager();
            userRepo = new UserRepository();
            smRepo = new SMRepository();
        }

        public void genereerAlerts(Element e)
        {
            userMgr.sendAlerts(e);
        }

        public Element getElement(int element_id)
        {
          return repo.getElement(element_id);
        }

        public Element getElement(string el, int platform_id)
        {
            if (el == null)
            {
              return null;
            }
            else
            {
              return repo.getElement(el, platform_id);
            }
        }


        public void politiciInlezen(int platform_id)
        {
      if(repo.getElements(platform_id).Count() < 100)
      {
        try
        {
          using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Data\politici.json"))
          {
            string json = r.ReadToEnd();

            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
              Persoon p = new Persoon();
              p.element_id = item.id;
              p.first_name = item.first_name;
              p.last_name = item.last_name;
              p.district = item.district;
              p.level = item.level;
              if (item.gender.ToString().ToLower().Equals("m"))
              {
                p.geslacht = Geslacht.Man;
              }
              else
              {
                p.geslacht = Geslacht.Vrouw;
              }
              p.twitter = item.twitter;
              p.site = item.site;
              DateTime date = item.dateOfBirth;
              p.geboorteDatum = date;
              p.facebook = item.facebook;
              p.postal_code = item.postal_code;
              p.naam = item.full_name;
              p.position = item.position;
              p.organisation = item.organisation;
              p.town = item.town;

              repo.addPersoon(p, 1);
            }
          }
        }
        catch (Exception e)
        {
          Console.WriteLine("The file could not be read:");
          Console.WriteLine(e.Message);
        }
      }
        }

        public void volgElement(int element_id, AlertType type, int user_id)
        {
            User u = repo.getUser(user_id);
            AlertInstellingen ai = new AlertInstellingen(type, u, repo.getElement(element_id));
            ai.element_id = element_id;
            ai.user_id = user_id;
            bool exists = false;

            foreach (AlertInstellingen aitest in repo.getAIs())
            {
                if (aitest.Equals(ai))
                {
                    ai = aitest;
                    exists = true;
                }
            }

            Element e = repo.getElement(element_id);
            if (!exists)
            {
                repo.getUser(user_id).alertInstellingen.Add(ai);

                e.alertInstellingen.Add(ai);
                repo.AddAI(ai);
                repo.addActiviteit(u, "Gebruiker volgt nu '" + e.naam + "'");
            }
            else
            {
                repo.RemoveAI(ai);
                repo.addActiviteit(u, "Gebruiker volgt '" + e.naam + "' niet meer");

            }
        }
        public Persoon getPersoon(Element element)
        {
            return repo.getPersoon(element.naam);
        }


        public void berekenPersoon(Persoon persoon)
        {

            int aantalVermeldingen = 0;
            double totaalPolariteit = 0;
            string[] verhalenUrls = { };
            string[] wordsList = { };
            bool mentioned = false;
            Dictionary<string, int> verhalen = new Dictionary<string, int>();
            Dictionary<string, int> woorden = new Dictionary<string, int>();
            foreach (Message m in smRepo.getMessages())
            {
                mentioned = false;
                if (m.persons.ToLower().Contains(persoon.naam.ToLower()))
                {
                    mentioned = true;
                }
                else if (m.words.ToLower().Contains(persoon.naam.ToLower()))
                {
                    mentioned = true;

                }
                else if (m.mentions.ToLower().Contains(persoon.twitter.ToLower()))
                {
                    mentioned = true;
                }

                {
                    if (mentioned)
                    {
                        aantalVermeldingen++;
                        if (m.sentiment.Length > 2)
                        {
                            List<Double> polariteit = splitData(m.sentiment).Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
                            double p = polariteit.Aggregate((x, y) => x * y);
                            totaalPolariteit += p;
                        }

                        if (m.urls.Length > 2)
                        {
                            List<string> urls = splitData(m.urls).ToList();
                            foreach (string u in urls)
                            {
                             string url = u.Remove(u.Length-3,3).Remove(0,1);
                             if (verhalen.ContainsKey(url))
                                {
                                    verhalen[url] += 1;
                                }
                                else
                                {   
                                    verhalen.Add(url, 1);
                                }
                            }
                            List<KeyValuePair<string, int>> verhalenLinks = verhalen.ToList();
                            verhalenLinks.Sort((u1, u2) => u1.Value.CompareTo(u2.Value));
                            if (verhalenLinks.Count > 3)
                            {
                                verhalenLinks.RemoveRange(2, verhalenLinks.Count - 3);
                            }
                            verhalenUrls = (from kvp in verhalenLinks select kvp.Key).ToArray();
                        }

            if (m.words.Length > 2)
            {
              List<string> words = splitData(m.words).ToList();
              foreach (string w in words)
              {
                string woord = w.Trim();
                woord = woord.Remove(woord.Length - 1, 1).Remove(0, 1);
                if (woorden.ContainsKey(woord))
                {
                  woorden[woord] += 1;
                }
                else
                {
                  woorden.Add(woord, 1);
                }
              }
              List<KeyValuePair<string, int>> woordenLijst = woorden.ToList();
              woordenLijst.Sort((u1, u2) => u1.Value.CompareTo(u2.Value));
              if (woordenLijst.Count > 5)
              {
                woordenLijst.RemoveRange(2, woordenLijst.Count - 5);
              }
              wordsList = (from kvp in woordenLijst select kvp.Key).ToArray();
            }

          }
        }

            }
            Persoon p1 = getPersoon(persoon);
            p1.polariteit = totaalPolariteit / aantalVermeldingen;
            p1.aantalVermeldingen = aantalVermeldingen;
            p1.verhalen = verhalenUrls;
            p1.woorden = wordsList;
            p1.trend = berekenTrend(p1);
        }


        public string[] splitData(string data)
        {
            string[] stringSeparators = new string[] { ",\r\n " };
            data = data.Trim().Remove(0, 5).Remove(data.Length - 8, 3);
            string[] gesplitsteData = data.Split(stringSeparators, StringSplitOptions.None);
            return gesplitsteData;
        }

    public IEnumerable<Element> getElements(int platform_id)
    {
      return repo.getElements(platform_id);
    }

        public void addElement(Element e, int platform_id, User u)
        {
            if (e.GetType().ToString().ToLower().Contains("organisatie"))
            {
                repo.addOrganisatie((Organisatie)e, platform_id);
                repo.addActiviteit(u, " Gebruiker voegde organistatie '" + e.naam + "' toe");
            }
            else if (e.GetType().ToString().ToLower().Contains("persoon"))
            {
                repo.addPersoon((Persoon)e, platform_id);
                repo.addActiviteit(u, " Gebruiker voegde persoon '" + e.naam + "' toe");
            }
            else if (e.GetType().ToString().ToLower().Contains("thema"))
            {
                repo.addThema((Thema)e, platform_id);
                repo.addActiviteit(u, " Gebruiker voegde thema '" + e.naam + "' toe");
            }

        }

        public void updateElement(Element element, int elementid, int platformid, User u)
        {
            repo.updateElement(element, elementid, platformid);
            repo.addActiviteit(u, " Gebruiker wijzigde '" + element.naam + "'");
        }

        public void deleteElement(int element_id)
        {
            repo.deleteElement(element_id);
        }
        public string berekenTrend(Element e)
        {
          double aantalVermeldingenVandaag = countVermeldingen(e, today.AddDays(-1), today);
          double aantalVermeldingen1 = countVermeldingen(e, today.AddDays(-2), today.AddDays(-1));
          double aantalVermeldingen2 = countVermeldingen(e, today.AddDays(-3), today.AddDays(-2));
          double aantalVermeldingen3 = countVermeldingen(e, today.AddDays(-4), today.AddDays(-3));
          double gemiddelde = (aantalVermeldingen1 + aantalVermeldingen2 + aantalVermeldingen3) / 3;

          double verandering = aantalVermeldingenVandaag / gemiddelde;

          if(verandering <= 0.5)
          {
            return "Sterke daling";
          }
          else if(verandering > 0.5 && verandering < 0.9)
          {
            return "Daling";
          }
          else if(verandering >= 0.9 && verandering <= 1.1)
          {
            return "Neutraal";
          }
          else if(verandering > 1.1 && verandering < 1.5)
          {
            return "Stijging";
          }
          else
          {
            return "Sterke stijging";
          }  
        }

    private int countVermeldingen(Element e, DateTime startDate, DateTime endDate)
    {
      int aantalVermeldingen = 0;

      foreach (Message m in smRepo.getMessages())
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

    public void deleteKeyword(int keyword_id, int element_id)
    {
      repo.deleteKeyword(keyword_id, element_id);
    }

    public void addKeyword(int element_id)
    {
      repo.addKeyword(element_id);
    }
  }
}
