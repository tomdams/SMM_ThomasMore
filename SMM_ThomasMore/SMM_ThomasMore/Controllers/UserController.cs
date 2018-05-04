using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class UserController
  {
    public static User currentUser { get; set; }
    private UserManager umgr;

    public UserController()
    {
      umgr = new UserManager();
    }

    public User getUser(string username, string wachtwoord)
    {
      return umgr.getUser(username, wachtwoord);
    }

    public void addUser(User user)
    {
      umgr.AddUser(user);
    }

        public void verifyUser(User user)
        {
            umgr.verifyUser(user);
        }

    public User getUserById(string id)
    {
      User u = umgr.getUserById(id);
      return u;
    }
    public void sendVerificationMail(User u) {
      int userid =  umgr.getUser(u.username,u.wachtwoord).user_id;
      umgr.sendVerificationMail(u);


    }
  }
}