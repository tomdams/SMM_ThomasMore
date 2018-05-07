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

    public void AddUser(User u)
    {
      Dashboard d = new Dashboard(u);
      u.dashboard = d;
      uctx.Users.Add(u);
      uctx.Dashboards.Add(d);
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
            uctx.Users.Find(u.user_id).username = "little bogger";
            uctx.SaveChanges();
        }
    }
}
