﻿
using System.Collections.Generic;
using SC.BL.Domain;
using SMM_ThomasMore.Domain;
namespace SMM_ThomasMore.BL
{
  public interface IElementManager
    {
        void genereerAlerts(Element e);
        void volgElement(int element_id, AlertType type, int user_id);
        void politiciInlezen(int platform_id);
        Element getElement(string el, int platform_id);
        Element getElement(int element_id);
        Persoon getPersoon(Element element);
        void berekenPersoon(Persoon persoon);
        IEnumerable<Element> getElements(int platform_id);
        void addElement(Element e, int id, User u);
        void updateElement(Element element, int elementid, int platformid, User u);

        void deleteElement(int element_id);
    void deleteKeyword(int keyword_id, int element_id);
    void addKeyword(int element_id);
  }
}
