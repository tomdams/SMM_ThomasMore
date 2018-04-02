using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.Controllers
{
    public class UserController : Controller
    {
    public User currentUser { get; set; }
    private UserManager umgr;

    public UserController()
    {
      umgr = new UserManager();
    }

    // GET: User
    public ActionResult AanmeldenPage()
        {
            return View();
        }

    /*[HttpPost]
    public ActionResult AanmeldenPage(UserVM userVM)
    {
      if (ModelState.IsValid)
      {
        if (umgr.isUser(userVM.username, userVM.wachtwoord))
        {

        }
        return View();
    }*/

    public ActionResult RegistrerenPage()
        {
          return View();
        }

    [HttpPost]
       public ActionResult RegistrerenPage(UserVM userVM)
       {
      if (ModelState.IsValid)
      {
          User newUser = new User()
          {
            wachtwoord = userVM.wachtwoord,
            compareWachtwoord = userVM.compareWachtwoord,
            email = userVM.email,
            username = userVM.username
          };
          umgr.AddUser(newUser);
        

        return View("~/Views/Home/Index.cshtml");
        }
        return View();
       }
         
    }
}