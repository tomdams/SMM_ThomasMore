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
    [Key]
    public int id { get; set; }
    public bool adminDashboard { get; set; }
    [Required]
    public virtual User user { get; set; }
    public virtual ICollection<Grafiek> grafieken { get; set; }
    [Required]
    public virtual Deelplatform deelplatform { get; set; }
    //public ICollection<Zone> zones { get; set; }

    public Dashboard()
    {
      grafieken = new List<Grafiek>();
    }

    public Dashboard(User u, Deelplatform d)
    {
      grafieken = new List<Grafiek>();
      user = u;
      deelplatform = d;
    }

        public override string ToString()
        {
            return user.username + "'s dashboard";
        }
    }


    
}
