using SC.BL.Domain.User;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models
{
  public class GrafiekVM
  {
    public int id { get; set; }
    public string titel { get; set; }
    public int plaats { get; set; }
    public bool kruising { get; set; }

    public string x_as { get; set; }
    public string y_as { get; set; }
    public string y_as1 { get; set; }
    public string y_as2 { get; set; }
    public string y_as3 { get; set; }
    public string y_as4 { get; set; }
    public string x_as_beschrijving { get; set; }
    public string y_as_beschrijving { get; set; }

    [Required]
    public DateTime beginDate { get; set; }
    [Required]
    public DateTime eindDate { get; set; }
    public string leeftijd { get; set; }
    public Geslacht? geslacht { get; set; }
    public Polariteit? polariteit { get; set; }
    public string opleiding { get; set; }

    public GrafiekOnderwerp grafiekOnderwerp { get; set; }
    public GrafiekType grafiekType { get; set; }

    public virtual ICollection<Element> elements { get; set; }
    public virtual ICollection<Dashboard> dashboards { get; set; }

    public Grafiek getGrafiek()
    {
      Grafiek g = new Grafiek();
      g.id = id;
      g.titel = titel;
      g.plaats = plaats;
      g.kruising = kruising;
      g.x_as = x_as;
      g.y_as = y_as:
      g.y_as1 = y_as1;
      g.y_as2 = y_as2;
      g.y_as3 = y_as3;
      g.y_as4 = y_as4;
      g.x_as_beschrijving = x_as_beschrijving;
      g.y_as_beschrijving = y_as_beschrijving;
      g.beginDate = beginDate;
      g.eindDate = eindDate;
      g.leeftijd = leeftijd;
      g.geslacht = geslacht;
      g.polariteit = polariteit;
      g.opleiding = opleiding;
      g.grafiekOnderwerp = grafiekOnderwerp;
      g.grafiekType = grafiekType;
      g.elements = elements;
      g.dashboards = dashboards;

      return g;
    }
  }
}