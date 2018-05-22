﻿using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            User u = umgr.getUser(username, wachtwoord);
            if (!(u is null))
            {
                List<Alert> alerts = new List<Alert>();
                foreach (Alert a in u.alerts)
                {
                    if (a.element.Deelplatform.id == PlatformController.currentDeelplatform.id)
                    {
                        alerts.Add(a);
                    }
                }
                u.alerts = alerts;
            }
            return u;
        }

        public string currentUserName()
        {
            return currentUser.username;
        }

        public void addUser(User user, int platformId)
        {
            umgr.AddUser(user, platformId);
        }

        public void verifyUser(string id)
        {
            umgr.verifyUser(id);
        }

        internal List<Deelplatform> getDashboards(User u)
        {
           return umgr.getDashboards(u);
        }

        public void setAlertGelezen(int alert_id)
        {
            umgr.setAlertGelezen(alert_id);
        }

        internal string ExportUsers(User user)
        {
            return umgr.ExportUsers(user);


        }
        public string Hash(string password)
        {

            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}