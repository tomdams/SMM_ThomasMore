using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SMM_ThomasMore.BL
{
  public  class ElementManager : IElementManager
    {
        private IElementRepository repo;
        private IUserManager userMgr;
        public ElementManager()
        {
            repo = new ElementRepository();
        }

        public void genereerAlerts()
        {
            IEnumerable<Element> elements = repo.getElements();
            userMgr = new UserManager();
            foreach (Element e in elements) {
                if (e.trending == true) {
                  userMgr.sendAlerts(e);
                }
            }

        }

        public void volgElement(string naam, AlertType type, User user)
        {
          Element e = null;
          List<Element> elements = repo.getElements().ToList();
          foreach(Element el in elements)
          {
            if (el.naam.Equals(naam))
            {
              e = el;
            }
          }

          AlertInstellingen ai = new AlertInstellingen(type, user, e);
          userMgr = new UserManager();
          userMgr.AddAI(ai);

    }
  }
}
