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
  }
}
