using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public string username { get; set; }
        public UserType type { get; set; }
        [NotMapped]
        [Required(ErrorMessage ="Wachtwoord moet herhaald worden!")]
        [CompareAttribute("wachtwoord", ErrorMessage ="Wachtwoorden komen niet overeen!")]
        public string compareWachtwoord { get; set; }


        
    }
}
