using SMM_ThomasMore.Models;
using SMM_ThomasMore.Session;
using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System.Web.Mvc;
using System.Web.Security;

namespace SMM_ThomasMore.Controllers
{

  public class UserController : Controller
    {
    public User currentUser { get; set; }
    private UserManager umgr;
    SessionContext context = new SessionContext();

    public UserController()
    {
      umgr = new UserManager();
    }

    // GET: User
    public ActionResult AanmeldenPage()
        {
            return View();
        }

    [HttpPost]
    public ActionResult AanmeldenPage(LoginVM loginVM)
    {
     
      if (ModelState.IsValid)
      {
        User authenticatedUser = umgr.getUser(loginVM.username, loginVM.wachtwoord);
        if (authenticatedUser != null)
        {
          currentUser = authenticatedUser;
          context.SetAuthenticationToken(authenticatedUser.id.ToString(), false, authenticatedUser);
          return RedirectToAction("Index", "Home");
        }
      }
      return View();
    
    }

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
         
    public ActionResult Afmelden()
    {
      FormsAuthentication.SignOut();
      return RedirectToAction("Index", "Home");
    }
    }
}