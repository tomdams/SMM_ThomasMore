using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class Zone
  {
    public int id { get; set; }

    public virtual Dashboard dashboard { get; set; }
  }
}
