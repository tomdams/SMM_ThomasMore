using System;
using System.Collections.Generic;
using System.Linq;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;

namespace SMM_ThomasMore.BL
{
  public class UserManager : IUserManager
  {
    private IUserRepository repo;
    public UserManager()
    {
      repo = new UserRepository();
    }

    public void sendAlert(User user, Element element, AlertType alertType)
    {

      if (alertType == AlertType.MAIL) {
        this.sendMail(user, element);
      }
      if (alertType == AlertType.MOBILENOTIFICATION)
      {
        this.sendMobileNotification(user, element);
      }
      if (alertType == AlertType.NOTIFICATION)
      {
        this.sendNotification(user, element);
      }

      Alert alert = new Alert(alertType, "", user, element);
      repo.addAlert(alert);
    }

    public User getUser(string username, string wachtwoord)
    {
      foreach (User u in repo.getUsers().ToList())
      {
        if (u.username.Equals(username) && u.wachtwoord.Equals(wachtwoord))
        {
          return u;
        }
      }
      return null;
    }
  

       
    public void sendAlerts(Element element)
        {
            IEnumerable<AlertInstellingen> ai = repo.GetAlertInstellingen();

            List<AlertInstellingen> alertinstellingenVoorElement = new List<AlertInstellingen>();

            foreach (AlertInstellingen alertinstelling in ai) {
            if (alertinstelling.element.id == element.id) {
                sendAlert(alertinstelling.user, alertinstelling.element, alertinstelling.type);
              }
            }
        }

        public void sendMail(User user, Element element)
        {
            Console.WriteLine("Trending: {0},  mail verstuurt naar {1}",element.naam,user.username);
        }

        public void sendMobileNotification(User user, Element element)
        {
            Console.WriteLine("Trending: {0},  mobilenotification verstuurt naar {1}", element.naam, user.username);
        }

        public void sendNotification(User user, Element element)
        {
            Console.WriteLine("Trending: {0},  notification verstuurt naar {1}", element.naam, user.username);
        }

        public User Aanmelden(string username)
        {
            foreach(User u in repo.getUsers().ToList())
            {
              if (u.username.Equals(username))
              {
                return u;
              }
            }
            return null;
        }

        public void AddAI(AlertInstellingen ai)
        {
          repo.AddAi(ai);
        }

    public void AddUser(User user)
    {
      repo.AddUser(user);
     
    }
  }
}
