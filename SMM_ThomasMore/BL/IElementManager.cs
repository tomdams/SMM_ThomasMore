
using System.Collections.Generic;
using SC.BL.Domain;
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.BL
{
  public interface IElementManager
    {
        void genereerAlerts(Element e);
        void volgElement(int element_id, AlertType type, int user_id);
        void politiciInlezen();
        Element getElement(string el, int platform_id);
        Element getElement(int element_id);
        Persoon getPersoon(Element element);
        void berekenPersoon(Persoon persoon);
        IEnumerable<Element> getElements(int platform_id);
        
  }
}
