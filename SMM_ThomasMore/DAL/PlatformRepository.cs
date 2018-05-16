using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.DAL
{
  public class PlatformRepository : IPlatformRepository
  {
    private SMMDbContext ctx;

    public PlatformRepository()

    {
      ctx = new SMMDbContext();
      ctx.Database.Initialize(false);
    }

    public Deelplatform GetDeelplatform(int id)
    {
      return ctx.Deelplatformen.Find(id);
    }
  }
}
