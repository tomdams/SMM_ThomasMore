using Newtonsoft.Json;
using SC.BL.Domain;
using SC.BL.Domain.SocialeMedia;
using SC.BL.Domain.User;
using SC.DAL;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
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

        public Element getElement(string el)
        {
            foreach (Element e in repo.getElements().ToList())
            {
                if (e.naam.ToLower().Equals(el.ToLower()))
                {
                    return e;
                }
            }
            return null;
        }


        public void politiciInlezen()
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

                        repo.addPersoon(p);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void volgElement(int element_id, AlertType type, int user_id)
        {
            AlertInstellingen ai = new AlertInstellingen(type, repo.getUser(user_id), repo.getElement(element_id));
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

            if (!exists)
            {
                repo.getUser(user_id).alertInstellingen.Add(ai);
                repo.getElement(element_id).alertInstellingen.Add(ai);
                repo.AddAI(ai);
            }
            else
            {
                repo.RemoveAI(ai);
            }
        }
        public Persoon getPersoon(Element element)
        {
            foreach (Persoon persoon in repo.getPersonen())
            {
                if (element.naam.Equals(persoon.naam))
                {
                    return persoon;
                }
            }
            return null;
        }


        public void berekenPersoon(Persoon persoon)
        {

            int aantalVermeldingen = 0;
            double totaalPolariteit = 0;
            string[] verhalenUrls = { };
            bool mentioned = false;
            Dictionary<string, int> verhalen = new Dictionary<string, int>();
            foreach (Message m in smRepo.getMessages())
            {
                mentioned = false;
                //   if (m.date > startDate && m.date < endDate)
                //  {
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

                //  }
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
                            foreach (string url in urls)
                            {
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
                    }
                }

            }
            Persoon p1 = getPersoon(persoon);
            p1.polariteit = totaalPolariteit / aantalVermeldingen;
            p1.aantalVermeldingen = aantalVermeldingen;
            p1.verhalen = verhalenUrls;
        }


        public string[] splitData(string data)
        {
            string[] stringSeparators = new string[] { ",\r\n " };
            data = data.Trim().Remove(0, 5).Remove(data.Length - 8, 3);
            string[] gesplitsteData = data.Split(stringSeparators, StringSplitOptions.None);
            return gesplitsteData;
        }
    }
}
