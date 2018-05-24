using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.BL
{
  public interface IPlatformManager
  {
    Deelplatform GetDeelplatform(int id);
    List<Deelplatform> GetDeelplatform();
    }
}
