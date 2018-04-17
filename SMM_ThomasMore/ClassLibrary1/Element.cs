using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Element
    {
        public int id { get; set;}
        public string naam { get; set; }
        public int aantalVermeldingen { get; set; }
        public string[] woorden { get; set; }
        public string[] verhalen { get; set; }
        public double polariteit { get; set; }
        public bool trending { get; set; }    
    }
}
