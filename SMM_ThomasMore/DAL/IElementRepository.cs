using SMM_ThomasMore.Domain;
using System.Collections.Generic;

namespace SMM_ThomasMore.DAL
{
  public interface IElementRepository
    {

        IEnumerable<Element> getElements();
       
    }
}
