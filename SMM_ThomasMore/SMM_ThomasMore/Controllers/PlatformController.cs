using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class PlatformController
  {
    private IPlatformManager mgr;
    public static Deelplatform currentDeelplatform;

    public PlatformController()
    {
      mgr = new PlatformManager();
    }

    public Deelplatform GetDeelplatform(int id)
    {
      return mgr.GetDeelplatform(id);
    }

        public List<Deelplatform> GetDeelplatformen()
        {
           return mgr.GetDeelplatform();
        }

        public void updateDeelplatform(Deelplatform d)
        {
            mgr.updateDeelplatform(d);
        }
    }
}