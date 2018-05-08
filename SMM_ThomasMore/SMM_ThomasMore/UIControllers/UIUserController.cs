using Facebook;
using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMM_ThomasMore.Controllers
{

    public class UIUserController : Controller
    {

    private UserController uc;
    public UIUserController()
    {
      uc = new UserController();
      if(UserController.currentUser != null)
      {
        UserController.currentUser = uc.getUser(UserController.currentUser.username, UserController.currentUser.wachtwoord);
      }
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
        User authenticatedUser = uc.getUser(loginVM.username, loginVM.wachtwoord);

        if (authenticatedUser != null)
        {
          UserController.currentUser = authenticatedUser;
          var authTicket = new FormsAuthenticationTicket(1, authenticatedUser.username, DateTime.Now, DateTime.Now.AddMinutes(30), true, authenticatedUser.type.ToString().ToLower());
          string cookieContents = FormsAuthentication.Encrypt(authTicket);
          var encTicket = FormsAuthentication.Encrypt(authTicket);
          Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
          
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
                    confirmEmail = false,
                    username = userVM.username
          };         
          uc.addUser(newUser);

                int userid = uc.getUser(newUser.username, newUser.wachtwoord).user_id;

                /* versturen van verificatie email */
                MailAddress from = new MailAddress("thomasmoreintegratie@gmail.com");
                MailAddress to = new MailAddress(userVM.email);
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Using email verification";
                message.Body = "http://localhost:11981/UIUser/verified/"+userid;
                
                
                using (var smtp =  new SmtpClient()) {
                    var credential = new NetworkCredential{
                        UserName = "thomasmoreintegratie@gmail.com", 
                         Password = "D9O8M7S6"  
                 };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    
                }
               
                
                
                

                /********/


        return View("~/Views/UIUser/Confirmation.cshtml");
        }
        return View();
       }

      public ActionResult UserBeherenPage() {


        return View();
      }


    public ActionResult Afmelden()
    {
      FormsAuthentication.SignOut();
      UserController.currentUser = null;
      return RedirectToAction("Index", "Home");
    }


    private Uri RedirectUri
    {
      get
      {
        var uriBuilder = new UriBuilder(Request.Url);
        uriBuilder.Query = null;
        uriBuilder.Fragment = null;
        uriBuilder.Path = Url.Action("FacebookCallback");
        return uriBuilder.Uri;
      }
    }

    [AllowAnonymous]
    public ActionResult Facebook()
    {
      var fb = new FacebookClient();
      var loginUrl = fb.GetLoginUrl(new
      {
        client_id = "378068569269286",
        client_secret = "c1d9470875260a1eb344e849022d9607",
        redirect_uri = RedirectUri.AbsoluteUri,
        response_type = "code",
        scope = "email"
      });

      return Redirect(loginUrl.AbsoluteUri);
    }

    public ActionResult FacebookCallback(string code)
    {
      var fb = new FacebookClient();
      dynamic result = fb.Post("oauth/access_token", new
      {
        client_id = "378068569269286",
        client_secret = "c1d9470875260a1eb344e849022d9607",
        redirect_uri = RedirectUri.AbsoluteUri,
        code = code
      });

      var accessToken = result.access_token;

      // Store the access token in the session for farther use
      Session["AccessToken"] = accessToken;

      // update the facebook client with the access token so
      // we can make requests on behalf of the user
      fb.AccessToken = accessToken;

      // Get the user's information, like email, first name, middle name etc
      dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
      string email = me.email;
      string firstname = me.first_name;
      string middlename = me.middle_name;
      string lastname = me.last_name;

      // Set the auth cookie
      FormsAuthentication.SetAuthCookie(email, false);
      return RedirectToAction("Index", "Home");
    }

    public ActionResult DashboardPage()
    {
      return View();
    }

    public ActionResult AlertInstellingenPage()
    {
      return View();
    }

    public ActionResult PlatformbeheerPage()
    {
      return View();
    }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SMBeherenPage()
    {
      return View();
    }

    public ActionResult DeelplatformenPage()
    {
      return View();
    }
     public ActionResult Verified()
     {
            
            return View();
     }
        public ActionResult Confirmation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verified(VerifyVM vm) {            
            uc.verifyUser(vm.id);
            return RedirectToAction("AanmeldenPage", "UIUser");
        }
    }
}