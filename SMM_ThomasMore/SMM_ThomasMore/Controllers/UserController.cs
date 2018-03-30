using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Aanmelden()
        {
            return View();
        }
        
        public ActionResult Registreren()
        {
          return View();
        }
    }
}