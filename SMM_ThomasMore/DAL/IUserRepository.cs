using SMM_ThomasMore.Domain;
using System.Collections.Generic;

namespace SMM_ThomasMore.DAL
{
  public interface IUserRepository
    {
        IEnumerable<User> getUsers();
        IEnumerable<AlertInstellingen> GetAlertInstellingen();
        void addAlert(Alert a);
        void AddAi(AlertInstellingen ai);
        void AddUser(User u);
   }
}
