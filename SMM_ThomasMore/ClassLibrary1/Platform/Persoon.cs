using SC.BL.Domain.User;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class Persoon : Element
  {
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string level { get; set; }
    public Geslacht geslacht { get; set; }
    public string twitter { get; set; }
    public string site { get; set; }
    public DateTime geboorteDatum { get; set; }
    public string facebook { get; set; }
    public string postal_code { get; set; }
    public string position { get; set; }
    public string organisation { get; set; }
    public string town { get; set; }
    public string district { get; set; }
    public Organisatie organisatie { get; set; }
  }
}
