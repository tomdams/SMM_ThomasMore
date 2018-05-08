using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public string currentUserName()
    {
      return currentUser.username;
    }

    public void addUser(User user)
    {
      umgr.AddUser(user);
    }

    public void verifyUser(string id)
    {
      umgr.verifyUser(id);
    }

    public void setAlertGelezen(int alert_id)
    {
      umgr.setAlertGelezen(alert_id);
    }
  }
}