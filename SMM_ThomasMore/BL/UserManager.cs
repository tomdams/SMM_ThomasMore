using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using System.Net.Mail;
using System.Net;

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

            Alert alert = new Alert(alertType, "", user, element);
            alert.message = element.naam + " is trending!";
            alert.date = DateTime.Now;
            alert.gelezen = false;
            user.alerts.Add(alert);
            element.alerts.Add(alert);
            repo.addAlert(alert);
        }

      

        public User getUser(string username, string wachtwoord)
        {
          foreach (User u in repo.getUsers().ToList())
          {
            if (u.username.Equals(username) && u.wachtwoord.Equals(wachtwoord))
            {
              repo.GetAlerts().ToList();
              return u;
            }
          }
          return null;
        }

        public string ExportUsers(User user)
        {
            String users = "sep=," + Environment.NewLine;
            users += "user_id, email, username, wachtwoord, type, confirmEmail, status " + Environment.NewLine;
            if (user.type == UserType.SUPERADMIN || user.type == UserType.ADMIN)
            {
                foreach (User u in repo.getUsers().ToList())
                {
                    users += u.export() + Environment.NewLine;
                }
            }
            repo.addActiviteit(user, "Gebruiker heeft een lijst van gebruikers geexporteerd");
            return users;
        }

        public string ExportActiviteit(int user_id)
        {
            String activiteit = "sep=," + Environment.NewLine;
            activiteit += " user_id, beschrijving, datum" + Environment.NewLine;
            foreach (Activiteit a in repo.getActiviteiten())
            {
                if (a.user_id == user_id)
                {
                    activiteit += a.export() + Environment.NewLine;
                }
            }
            return activiteit;
        }

        public List<Deelplatform> getDashboards(User u)
        {
            IEnumerable<Dashboard> db = repo.getDashboards();
            List<Deelplatform> deelplatformen = new List<Deelplatform>();
            foreach (Dashboard d in db) {
                if (d.user.Equals(u)) {
                    deelplatformen.Add(d.deelplatform);
                }
            }


            return deelplatformen;

        }

        public void updateUser(User u, int user_id, User currentUser)
        {
            repo.updateUser(u, user_id);
            u = repo.getUser(user_id);
            repo.addActiviteit(u, "Gebruiker werd geupdate door '" + currentUser.username + "'");
            repo.addActiviteit(currentUser, "Gebruiker heeft user '" + u.username + "' geupdate");
        }

        public User getUserByID(int user_id)
        {
            foreach (User u in repo.getUsers().ToList())
            {
                if (u.user_id.Equals(user_id))
                {
                    return u;
                }
            }
            return null;
        }

        public void logLogon(User u)
        {

            repo.addActiviteit(u, "Gebruiker heeft zich aangemeld");
        }

        public void sendAlerts(Element element)
        {
            IEnumerable<AlertInstellingen> ai = repo.GetAlertInstellingen();

            List<AlertInstellingen> alertinstellingenVoorElement = new List<AlertInstellingen>();

            foreach (AlertInstellingen alertinstelling in ai) {
            if (alertinstelling.element.element_id == element.element_id) {
                sendAlert(alertinstelling.user, alertinstelling.element, alertinstelling.type);
              }
            }
        }

        public void sendMail(User user, Element element)
        {
      /* versturen van verificatie email */
      MailAddress from = new MailAddress("thomasmoreintegratie@gmail.com");
      MailAddress to = new MailAddress(user.email);
      MailMessage message = new MailMessage(from, to);
      message.Subject = "Trending Alert Sociale Media Monitor";
      message.Body = element.naam + " is Trending";


      using (var smtp = new SmtpClient())
      {
        var credential = new NetworkCredential
        {
          UserName = "thomasmoreintegratie@gmail.com",
          Password = "D9O8M7S6"
        };
        smtp.Credentials = credential;
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.Send(message);

      }
    }

        public void sendMobileNotification(User user, Element element)
        {
            Console.WriteLine("Trending: {0},  mobilenotification verstuurt naar {1}", element.naam, user.username);
        }

      

        public void AddAI(AlertInstellingen ai)
        {
          repo.AddAi(ai);
        }

    public void AddUser(User user, int platformId)
    {
      repo.AddUser(user, platformId);
     
    }

        public void verifyUser(string id)
        {
            foreach (User u in repo.getUsers().ToList()) {
                if (u.user_id.ToString().Equals(id)) {
                    repo.verifyUser(u);
                    repo.addActiviteit(u, "Gebruiker heeft zijn account geverifieerd");

                    break;
                }
            }
        }
        public IEnumerable<User> getUsers()
        {
            return repo.getUsers();
        }

        public User getUser(int id)
        {
            return repo.getUser(id);
        }

    public void setAlertGelezen(int alert_id)
    {
      repo.setALertGelezen(alert_id);
    }
  }
}
