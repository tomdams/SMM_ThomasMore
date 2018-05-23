using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Organisatie : Element
    {
        public string profiel { get; set; }
        public string gemeente { get; set; }
        public virtual ICollection<Persoon> personen { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }

  }
}
