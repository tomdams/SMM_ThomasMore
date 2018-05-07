using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.Controllers
{

  public class HomeController : Controller
  {
        private ElementController elController;
        private SMController sMController;
        private static bool ingelezen = false;
        public ActionResult Index()
        {
            elController = new ElementController();
            sMController = new SMController();
            if (!ingelezen)
            {
                elController.politiciInlezen();
                //sMController.readMessages();
                ingelezen = true;
            }
            return View();
        }

        public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

     public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

        public ActionResult PlatformenPage()
    {
      return View();
    }

    public ActionResult LoginPage()
    {
            ViewBag.Message = "Your application description page.";

            return View();
    }
    }
}