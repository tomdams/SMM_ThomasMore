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
      uctx.Users.Add(u);
      uctx.SaveChanges();
    }


    public IEnumerable<AlertInstellingen> GetAlertInstellingen()
        {
           return uctx.AlertInstellingen.ToList<AlertInstellingen>();
        }

        public IEnumerable<User> getUsers()
        {
           return uctx.Users.ToList<User>();
        }

        public void AddAi(AlertInstellingen ai)
        {
          uctx.AlertInstellingen.Add(ai);
          uctx.SaveChanges();
        }

        public void verifyUser(User u)
        {
      uctx.Users.Find(u.id).confirmEmail = true;
            
            
            uctx.SaveChanges();
         
        }
    }
}
