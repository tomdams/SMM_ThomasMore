using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Thema : Element
    {
    public virtual List<Keyword> keywords { get; set; }

    public Thema()
    {
      keywords = new List<Keyword>();
    }
  }
}
