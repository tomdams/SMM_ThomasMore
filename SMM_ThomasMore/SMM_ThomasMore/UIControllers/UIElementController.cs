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
            element = elController.getElement(el.naam);
            if (element != null)
            {
                if (element.GetType() == typeof(Persoon))
                {
                    Persoon persoon = elController.getPersoon(element);
                      elController.berekenPersoon(persoon);
                    return View("~/Views/UIElement/PersoonPage.cshtml", persoon);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        
        public ActionResult volgElement()
        {
            if (UserController.currentUser != null)
            {
               elController.volgElement(element.element_id, AlertType.NOTIFICATION, UserController.currentUser.user_id);
            }
            return View("~/Views/UIElement/PersoonPage.cshtml", element);
        }

        public ActionResult leesMessages()
        {
          smc.readMessages();
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
            if (element.GetType() == typeof(Persoon))
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
        if (element.GetType() == typeof(Persoon))
        {
          persoon = elController.getPersoon(element);
        }
      }
      return Redirect("https://twitter.com/" + persoon.twitter + "/profile_image?size=original");
    }
  }
}