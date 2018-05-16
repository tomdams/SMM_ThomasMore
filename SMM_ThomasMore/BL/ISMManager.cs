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
    void readMessages(int platform_id);
    void checkTrending(int platform_id);
    bool checkTrending(Element e);
  }
}