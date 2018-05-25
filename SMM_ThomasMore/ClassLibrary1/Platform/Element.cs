﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Element : IComparable<Element>
    {
        [Key]
        public int element_id { get; set;}
        public string naam { get; set; }
        public int aantalVermeldingen { get; set; }
        public string[] woorden { get; set; }
        public string[] verhalen { get; set; }
        public double polariteit { get; set; }
        public string trend { get; set; }
        public virtual ICollection<AlertInstellingen> alertInstellingen { get; set; }
        public virtual ICollection<Alert> alerts { get; set; }
        public virtual ICollection<Grafiek> grafieken { get; set; }
        [Required]
        public virtual Deelplatform Deelplatform { get; set; }

        public Element()
        {
            alertInstellingen = new List<AlertInstellingen>();
            alerts = new List<Alert>();
            grafieken = new List<Grafiek>();
        }

        public int CompareTo(Element other)
        {
           return naam.CompareTo(other.naam);
        }

    public override bool Equals(object obj)
    {
      var element = obj as Element;
      return element != null &&
             element_id == element.element_id;
    }

    public override int GetHashCode()
    {
      return -1494058323 + element_id.GetHashCode();
    }
  }
}
