using SMM_ThomasMore.Domain;
using System.Collections;
using System.Collections.Generic;

namespace SMM_ThomasMore.BL
{
  public interface IUserManager
    {
        void sendAlerts(Element element);
        void sendAlert(User user, Element element, AlertType alertType);
        void sendMail(User user, Element element);
        void sendMobileNotification(User user, Element element);
        void AddAI(AlertInstellingen ai);
        void setAlertGelezen(int alert_id);
        IEnumerable<User> getUsers();
        User getUser(int id);
        void AddUser(User u, int platformId);
    }
}
