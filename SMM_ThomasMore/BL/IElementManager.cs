
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.BL
{
  public interface IElementManager
    {
        void genereerAlerts();
        void volgElement(string naam, AlertType type, User user);
    }
}
