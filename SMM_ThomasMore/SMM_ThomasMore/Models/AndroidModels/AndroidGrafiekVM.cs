using SC.BL.Domain.User;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models.AndroidModels
{
    public class AndroidGrafiekVM
    {
        public int id;
        public string titel;
        public int plaats;
        public bool kruising;
        public string x_as;
        public string y_as;
        public string y_as1;
        public string y_as2;
        public string y_as3;
        public string y_as4;
        public string x_as_beschrijving;
        public string y_as_beschrijving;

        public List<AndroidElementVM> elements;
        public string leeftijd;
        public Geslacht? geslacht;
        public Polariteit? polariteit;
        public string opleiding;
      
        public GrafiekOnderwerp grafiekOnderwerp;
        public GrafiekType grafiekType;
    }
}