using System;
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
        this.sendMailNotification(user, element);
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

    public void sendVerificationMail(User u)
    {

      int userid = getUser(u.username, u.wachtwoord).id;

      /* versturen van verificatie email */
      
      
      string subject = "Using email verification";
      string body = "http://localhost:11981/UIUser/verified/" + userid;
      sendMail(u.email, subject, body);

     



    }
    public void sendMail(string ontvanger,string subject,string body) {

      MailAddress from = new MailAddress("thomasmoreintegratie@gmail.com");
      MailAddress to = new MailAddress(ontvanger);
      MailMessage message = new MailMessage(from, to);
      message.Subject = subject;
      message.Body = body;



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

    public void sendMailNotification(User user, Element element) => sendMail(user.email, "Een item is trending", " is nu trending");




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

        public void verifyUser(User user)
        {
            foreach (User u in repo.getUsers().ToList()) {
                if (u.Equals(user)) {
                    repo.verifyUser(u);
                    break;
                }
            }
        }

    public User getUserById(string id)
    {
      foreach (User u in repo.getUsers().ToList())
      {
        int userid = Convert.ToInt32(id);
        bool test = userid == u.id;
        if (u.id==userid)
        {
          return u;

        }
      }
      return null;
    }

  }
}
