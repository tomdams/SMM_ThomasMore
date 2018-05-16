using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class Deelplatform
  {
    [Key]
    public int id { get; set; }
    public string naam { get; set; }

    public ICollection<Element> elements;

    public Deelplatform()
    {
      elements = new List<Element>();
    }
  }
}
