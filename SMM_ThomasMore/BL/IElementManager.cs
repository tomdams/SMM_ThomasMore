
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.BL
{
  public interface IElementManager
    {
        void genereerAlerts(Element e);
        void volgElement(int element_id, AlertType type, int user_id);
        void politiciInlezen();
    }
}
