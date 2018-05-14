using SMM_ThomasMore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.UIControllers
{
    public class AndroidController : Controller
    {
        private UserController uc;
        public AndroidController()
        {
            uc = new UserController();
            if (UserController.currentUser != null)
            {
                UserController.currentUser = uc.getUser(UserController.currentUser.username, UserController.currentUser.wachtwoord);
            }
        }
        // GET: Android
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public string Login(string username,string password)
        {
            return "antwoord van de webapp";
        }
    }
}