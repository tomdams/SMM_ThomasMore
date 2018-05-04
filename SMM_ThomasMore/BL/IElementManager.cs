
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.BL
{
  public interface IElementManager
    {
        void genereerAlerts(Element e);
        void volgElement(string naam, AlertType type, User user);
        void politiciInlezen();
  }
}
