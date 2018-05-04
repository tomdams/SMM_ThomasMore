using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.BL
{
  public interface ISMManager
  {
    void readMessages();
    void checkTrending();
    bool checkTrending(Element e);
  }
}