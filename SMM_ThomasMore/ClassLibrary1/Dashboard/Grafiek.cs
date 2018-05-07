using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class Grafiek
  {
    public int id { get; set; }
    public string titel { get; set; }
    public int plaats { get; set; }
    public string x_as { get; set; }
    public string y_as { get; set; }
    public string x_as_beschrijving { get; set; }
    public string y_as_beschrijving { get; set; }
    public GrafiekType grafiekType { get; set; }
    public ICollection<Element> elements { get; set; }
    [Required]
    public virtual Dashboard dashboard { get; set; }

    public Grafiek(Dashboard d)
    {
      elements = new List<Element>();
      dashboard = d;
    }
  }
}
