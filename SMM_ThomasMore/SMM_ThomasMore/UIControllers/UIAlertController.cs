using SMM_ThomasMore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.UIControllers
{
    public class UIALertController : Controller
    {
        private UserController uc = new UserController();
        private ElementController ec = new ElementController();
        private SMController smc = new SMController();
        // GET: UIALert
        public ActionResult AlertInstellingenPage()
        {
            return View();
        }

        public ActionResult volgElement()
        {
            ec.volgElement(254, Domain.AlertType.NOTIFICATION, UserController.currentUser.user_id);
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult leesMessages()
        {
            smc.readMessages();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}