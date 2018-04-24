using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;

namespace SMM_ThomasMore.DAL
{
  public interface IElementRepository
    {

        IEnumerable<Element> getElements();
        void addPersoon(Persoon p);
  }
}
