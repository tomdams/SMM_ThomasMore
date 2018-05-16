using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.DAL
{
  public interface IPlatformRepository
  {
    Deelplatform GetDeelplatform(int id);
  }
}
