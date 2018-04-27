using SMM_ThomasMore.Domain;

namespace SMM_ThomasMore.BL
{
  public interface IUserManager
    {
        void sendAlerts(Element element);
        void sendAlert(User user, Element element, AlertType alertType);
        void sendNotification(User user, Element element);
        void sendMail(User user, Element element);
        void sendMobileNotification(User user, Element element);
        void AddAI(AlertInstellingen ai);
        void verifyUser(User user);

    }
}
