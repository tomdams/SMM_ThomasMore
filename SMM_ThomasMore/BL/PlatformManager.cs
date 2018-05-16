using SMM_ThomasMore.DAL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.BL
{
  public class PlatformManager : IPlatformManager
  {
    private IPlatformRepository repo;

    public PlatformManager()
    {
      repo = new PlatformRepository();
    }

    public Deelplatform GetDeelplatform(int id)
    {
      return repo.GetDeelplatform(id);
    }
  }
}
