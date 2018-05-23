using SC.BL.Domain;
using SMM_ThomasMore.Controllers;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.UIControllers
{
    public class UIElementController : Controller
    {
        private ElementController elController = new ElementController();
        private UserController uc = new UserController();
        private SMController smc = new SMController();
        private static Element element;

        // GET: UIElement
        public UIElementController()
        {
          if (UserController.currentUser != null)
          {
            UserController.currentUser = uc.getUser(UserController.currentUser.username, UserController.currentUser.wachtwoord);
          }
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ElementPage(Element el)
        {
            element = elController.GetElement(el.naam);

            if (element != null)
            {
                if (element.GetType().ToString().ToLower().Contains("persoon"))
                {
                    Persoon persoon = elController.getPersoon(element);
                    elController.berekenPersoon(persoon);
                    return View("~/Views/UIElement/PersoonPage.cshtml", persoon);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        
        public ActionResult volgElement(int type)
        {
            AlertType alertType = AlertType.NOTIFICATION;
            switch (type)
            {
              case 1: alertType = AlertType.NOTIFICATION; break;
              case 2: alertType = AlertType.MOBILENOTIFICATION; break;
              case 3: alertType = AlertType.MAIL; break;
            }
            if (UserController.currentUser != null)
            {
               elController.volgElement(element.element_id, alertType, UserController.currentUser.user_id);
            }
            return View("~/Views/UIElement/PersoonPage.cshtml", element);
        }

        public ActionResult leesMessages()
        {
          smc.readMessages(PlatformController.currentDeelplatform.id);
          return View("~/Views/UIElement/PersoonPage.cshtml", element);
        }

        public ActionResult Twitter()
         {
            Persoon persoon = new Persoon();
            if (element != null)
            {
                if (element.GetType() == typeof(Persoon))
                {
                    persoon = elController.getPersoon(element);
                }
            }
            return Redirect("https://twitter.com/" + persoon.twitter);
        }

        public ActionResult Facebook()
        {
            Persoon persoon = new Persoon();
            if (element != null)
            {
                if (element.GetType() == typeof(Persoon))
                {
                    persoon = elController.getPersoon(element);
                }
            }
            return Redirect(persoon.facebook);
        }

        public ActionResult AfterAlertElementPage(int element_id, int alert_id)
        {
          uc.setAlertGelezen(alert_id);
          element = elController.GetElement(element_id);
          if (element != null)
          {
            if (element.GetType().ToString().ToLower().Contains("persoon"))
            {
              Persoon persoon = elController.getPersoon(element);
              elController.berekenPersoon(persoon);
              return View("~/Views/UIElement/PersoonPage.cshtml", element);
            }
          }

          return View("~/Views/Home/Index.cshtml");
        }

    [HttpPost]
    public double getPolariteit()
    {
      return element.polariteit;
    }

    public ActionResult TwitterPic()
    {
      Persoon persoon = new Persoon();
      if (element != null)
      {
        if (element.GetType().ToString().ToLower().Contains("persoon"))
        {
          persoon = elController.getPersoon(element);
        }
      }
      return Redirect("https://twitter.com/" + persoon.twitter + "/profile_image?size=original");
    }

    [Authorize(Roles = "superadmin,admin")]
    public ActionResult ElementBeherenPage()
    {
      List<Element> elementen = elController.getElements().ToList();
      return View(elementen);
    }


    public ActionResult EditThema(int elementId)
    {
      element = elController.GetElement(elementId);
      return View("~/Views/UIElement/NewThema.cshtml", element);
    }

    public ActionResult EditPersoon(int elementId)
    {
      element = elController.GetElement(elementId);
      return View("~/Views/UIElement/NewPersoon.cshtml",element);
    }

    public ActionResult EditOrganisatie(int elementId)
    {
      element = elController.GetElement(elementId);
      return View("~/Views/UIElement/NewOrganisatie.cshtml",element);
    }

    public ActionResult CreateOrganisatie()
    {
      element = new Organisatie();
      return View("~/Views/UIElement/NewOrganisatie.cshtml");
    }
    public ActionResult CreateThema()
    {
      element = new Organisatie();
      return View("~/Views/UIElement/NewThema.cshtml");
    }

    public ActionResult CreatePersoon()
    {
      element = new Organisatie();
      return View("~/Views/UIElement/NewPersoon.cshtml");
    }
    [HttpPost]
    public ActionResult CreateThema(Thema t)
    {
      if (element.element_id == 0)
      {
        elController.addElement(t);
      }
      else
      {
        elController.updateElement(t, element.element_id);
      }
     
      return View("~/Views/UIElement/ElementBeherenPage.cshtml", elController.getElements().ToList());
    }
    [HttpPost]
    public ActionResult CreatePersoon(Persoon p)
    {
      if (element.element_id == 0)
      {
        elController.addElement(p);
      }
      else
      {
        elController.updateElement(p, element.element_id);
      }
      return View("~/Views/UIElement/ElementBeherenPage.cshtml", elController.getElements().ToList());
    }
    [HttpPost]
    public ActionResult CreateOrganisatie(Organisatie o)
    {
      if (element.element_id == 0)
      {
        elController.addElement(o);
      }
      else
      {
        elController.updateElement(o, element.element_id);
      }
      return View("~/Views/UIElement/ElementBeherenPage.cshtml", elController.getElements().ToList());
    }

    public ActionResult DeleteElement(int element_id)
    {
      elController.deleteElement(element_id);
      return View("~/Views/UIElement/ElementBeherenPage.cshtml", elController.getElements().ToList());
    }

  }
}