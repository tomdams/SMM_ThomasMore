using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;
using SC.BL.Domain.User;

namespace SMM_ThomasMore.Domain
{
  public class Grafiek
  {
    [Key]
    public int id { get; set; }
    public string titel { get; set; }
    public int plaats { get; set; }

    public string x_as { get; set; }
    public string y_as { get; set; }
    public string x_as_beschrijving { get; set; }
    public string y_as_beschrijving { get; set; }

    public DateTime beginDate { get; set; }
    public DateTime eindDate { get; set; }
    public string leeftijd { get; set; }
    public Geslacht? geslacht { get; set; }
    public Polariteit? polariteit { get; set; }
    public string opleiding { get; set; }

    public GrafiekOnderwerp grafiekOnderwerp { get; set; }
    public GrafiekType grafiekType { get; set; }

    public virtual Element element { get; set; }
    public virtual ICollection<Dashboard> dashboards { get; set; }

    public Grafiek()
    {
      dashboards = new List<Dashboard>();
    }

    public Grafiek(Dashboard d)
    {
      dashboards = new List<Dashboard>();
      dashboards.Add(d);
    }
  }
}

