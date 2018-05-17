using System.Collections.Generic;
using System.Linq;
using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.DAL
{
  public class UserRepository : IUserRepository
    {
        private SMMDbContext uctx;

        public UserRepository()
        {
            uctx = new SMMDbContext();
            uctx.Database.Initialize(false);
        }

        public void addAlert(Alert a)
        {
            uctx.Alerts.Add(a);
            uctx.SaveChanges();
        }

        public void AddUser(User u, int platformId)
        {
          Deelplatform p = uctx.Deelplatformen.Find(platformId);
          Dashboard d = new Dashboard(u, p);
          if (u.type.Equals(UserType.ADMIN))
          {
            d.adminDashboard = true;
          }
          else
          {
            d.adminDashboard = false;
            foreach(Dashboard dashboard in p.dashboards)
            {
              if (dashboard.adminDashboard)
              {
                foreach(Grafiek g in dashboard.grafieken)
                {
                  d.grafieken.Add(g);
                  g.dashboards.Add(d);
                }
              }
            }
          }
          u.dasboards.Add(d);
          p.dashboards.Add(d);
          
          uctx.Dashboards.Add(d);
          uctx.Users.Add(u);
          uctx.SaveChanges();
        }


        public IEnumerable<AlertInstellingen> GetAlertInstellingen()
        {
           return uctx.AlertInstellingen.ToList<AlertInstellingen>();
        }

        public IEnumerable<User> getUsers()
        {
            List<User> users = new List<User>();
            foreach (User u in uctx.Users)
            {
                users.Add(u);
            }
            return users;
        }

        public User getUser(int id)
        {
            foreach (User u in uctx.Users)
            {
                if (u.user_id == id)
                {
                    return u;
                }
            }

            return null;
        }
        public void AddAi(AlertInstellingen ai)
        {
          uctx.AlertInstellingen.Add(ai);
          uctx.SaveChanges();
        }

        public void verifyUser(User u)
        {
            uctx.Users.Find(u.user_id).confirmEmail = true;
            uctx.SaveChanges();
        }

        public IEnumerable<Alert> GetAlerts()
        {
          return uctx.Alerts.ToList<Alert>();
        }

        public void setALertGelezen(int alert_id)
        {
            Alert a = uctx.Alerts.Find(alert_id);
            a.gelezen = true;
            uctx.SaveChanges();
        }
  }
}
