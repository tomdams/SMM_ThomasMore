﻿using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class UserController
  {
    public User currentUser { get; set; }
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
  }
}