using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class Dashboard
  {
    public int id { get; set; }

    [Required]
    public virtual User user { get; set; }
    public ICollection<Grafiek> grafieken { get; set; }
    //public ICollection<Zone> zones { get; set; }

    public Dashboard()
        {
            grafieken = new List<Grafiek>();
        }

    public Dashboard(User u)
    {
      grafieken = new List<Grafiek>();
      user = u;
    }
  }
}
