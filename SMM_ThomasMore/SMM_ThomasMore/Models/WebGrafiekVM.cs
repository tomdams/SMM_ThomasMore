using SC.BL.Domain.User;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models
{
  public class WebGrafiekVM
  {
    public string elementNaam { get; set; }
    public Grafiek grafiek { get; set; }

    public WebGrafiekVM()
    {
      grafiek = new Grafiek();
    }

    public WebGrafiekVM(Grafiek g)
    {
      grafiek = g;
    }
  }
}