using SMM_ThomasMore.Domain;
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
        private UserController uController;
        private static bool ingelezen = false;
        private DashboardController dbController;

        public HomeController()
        { 
          if (UserController.currentUser != null)
          {
            uController = new UserController();
            UserController.currentUser = uController.getUser(UserController.currentUser.username, UserController.currentUser.wachtwoord);
          }
        }
        public ActionResult Index()
        {
            elController = new ElementController();
            sMController = new SMController();
            dbController = new DashboardController();
            //dbController.UpdateGrafieken();
            if (!ingelezen)
            {
                elController.politiciInlezen();
                ingelezen = true;
            }


            if (!(UserController.currentUser == null))
            {
              ViewBag.dashboard = dbController.GetDashboard(UserController.currentUser);
                ViewBag.user = UserController.currentUser;
              
                return View();
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