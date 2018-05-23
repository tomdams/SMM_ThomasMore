using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Activiteit
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public virtual User user { get; set; }
        public string beschrijving { get; set; }
        public DateTime datum { get; set; }

        public string export()
        {
            string a = "";
            a = user_id + "," + beschrijving + "," + datum;
            return a;
        }
    }
}
