using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Persoon : Element
    {
        public string profiel { get; set; }
        public string gemeente { get; set; }
        public Organisatie organisatie { get; set; }

    }
}
