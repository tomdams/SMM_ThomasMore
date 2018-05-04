using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.UIControllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult UnauthorizedError()
        {            
            return View();
        }
    }
}