using Newtonsoft.Json;
using SC.BL.Domain;
using SC.BL.Domain.User;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SMM_ThomasMore.BL
{
  public  class ElementManager : IElementManager
    {
        private IElementRepository repo;
        private IUserManager userMgr;
        public ElementManager()
        {
            repo = new ElementRepository();
            userMgr = new UserManager();
        }



    public void genereerAlerts(Element e)
    {
      userMgr.sendAlerts(e);
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
            p.id = item.id;
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

    public void volgElement(string naam, AlertType type, User user)
        {
          Element e = null;
          List<Element> elements = repo.getElements().ToList();
          foreach(Element el in elements)
          {
            if (el.naam.Equals(naam))
            {
              e = el;
            }
          }

          AlertInstellingen ai = new AlertInstellingen(type, user, e);
          userMgr.AddAI(ai);

    }
  }
}
