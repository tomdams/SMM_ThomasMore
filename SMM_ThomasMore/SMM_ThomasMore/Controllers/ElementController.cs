﻿using SC.BL.Domain;
using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class ElementController
  {

    private IElementManager mgr;
        public static Element currentelement { get; set; }

        public ElementController()
        {
            ElementController.currentelement = new Element();
            mgr = new ElementManager();
        }

        public void volgElement(int element_id, AlertType type, int user_id)
        {
            mgr.volgElement(element_id, type, user_id);
        }

        public void politiciInlezen()
        {
          mgr.politiciInlezen(PlatformController.currentDeelplatform.id);
        }
        public Element GetElement(string naam)
        {
            return mgr.getElement(naam, PlatformController.currentDeelplatform.id);
        }

        public Persoon getPersoon(Element element)
        {
            return mgr.getPersoon(element);
        }


        public void berekenPersoon(Persoon persoon)
        {
            mgr.berekenPersoon(persoon);
        }

        public Element GetElement(int element_id)
        {
          return mgr.getElement(element_id);
        }

    public void addElement(Element e)
    {
      mgr.addElement(e, PlatformController.currentDeelplatform.id, UserController.currentUser);
    }

    public IEnumerable<Element> getElements()
    {
      return mgr.getElements(PlatformController.currentDeelplatform.id);
    }

        public void updateElement(Element element, int elementid)
        {
            mgr.updateElement(element, elementid, PlatformController.currentDeelplatform.id, UserController.currentUser);
        }

        internal void deleteElement(int element_id)
        {
          mgr.deleteElement(element_id);
        }

        internal void deleteKeyword(int keyword_id, int element_id)
        {
          mgr.deleteKeyword(keyword_id, element_id);
        }

    internal void addKeyword(int element_id)
    {
      mgr.addKeyword(element_id);
    }
  }
}