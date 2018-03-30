using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public  class Keyword
    {
        public string woord { get; set; }
        public int aantalVermeldingen { get; set; }
        public bool trending { get; set; }
        public Thema thema { get; set; }
    }
}
