﻿using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;

namespace SMM_ThomasMore.DAL
{
  public interface IElementRepository
    {
        IEnumerable<Element> getElements();
        Element getElement(int id);
        User getUser(int id);
        void addPersoon(Persoon p);
        void AddAI(AlertInstellingen ai);
        IEnumerable<AlertInstellingen> getAIs();
        void RemoveAI(AlertInstellingen ai);
    }
}
