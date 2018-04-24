using SC.BL.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.BL.Domain.SocialeMedia
{
  public class Message
  {
    public string source { get; set; }
    public string id { get; set; }
    public string geo { get; set; }
    public string mentions { get; set; }
    public bool retweet { get; set; }
    public DateTime? date { get; set; }
    public string words { get; set; }
    public string sentiment { get; set; }
    public string hashtags { get; set; }
    public string urls { get; set; }
    public string themas { get; set; }
    public string persons { get; set; }
    public string age { get; set; }
    public Geslacht geslacht { get; set; }
    public string education { get; set; }
    public string personality { get; set; }
    public string language { get; set; }
  }
}

