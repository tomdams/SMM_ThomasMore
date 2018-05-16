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

        public ICollection<Grafiek> getGrafieken()
        {

            //List<Grafiek> returnGrafieken = new List<Grafiek>();

            //foreach (Grafiek g in grafieken)
            //{
            //    returnGrafieken.Add(g);
            //}
            //return returnGrafieken;

            return grafieken;

            

            
        }
    }


    
}
