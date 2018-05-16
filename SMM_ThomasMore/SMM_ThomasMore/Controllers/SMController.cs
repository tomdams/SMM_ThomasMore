using SC.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class SMController
  {
    private ISMManager mgr;

    public void readMessages(int platform_id)
    {
      mgr = new SMManager();
      mgr.readMessages(platform_id);
    }

  }
}