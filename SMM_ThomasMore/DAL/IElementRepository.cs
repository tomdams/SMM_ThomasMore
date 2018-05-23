using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;

namespace SMM_ThomasMore.DAL
{
  public interface IElementRepository
    {
        IEnumerable<Element> getElements(int platform_id);
        Element getElement(int element_id);
        Element getElement(string naam, int platform_id);
        User getUser(int id);
        void addPersoon(Persoon p, int platformid);
        void AddAI(AlertInstellingen ai);
        IEnumerable<AlertInstellingen> getAIs();
        void RemoveAI(AlertInstellingen ai);
        IEnumerable<Persoon> getPersonen();
        Persoon getPersoon(string naam);
        Organisatie getOrganisatie(string organisation);
        void addOrganisatie(Organisatie o, int platformid);
        void addThema(Thema e, int platform_id);
    void updateElement(Element element, int elementid, int platformid);
    void deleteElement(int element_id);
        void addActiviteit(User u, string message);
    }
}
