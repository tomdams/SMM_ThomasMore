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
        private static Element element;
        // GET: UIElement
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
                    return View("~/Views/UIElement/PersoonPage.cshtml", element);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult volgElement()
        {
            if (UserController.currentUser != null)
            {
                //    elController.volgElement(element, AlertType.NOTIFICATION, UserController.currentUser);
            }
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

    }
}