using SC.BL.Domain.User;
using SMM_ThomasMore.Controllers;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.UIControllers
{
  public class UIDashboardController : Controller
  {
    ElementController ec = new ElementController();
    DashboardController dc = new DashboardController();
    private UserController uc;
    private static WebGrafiekVM lastGrafiekVM;

        public UIDashboardController()
        {
            uc = new UserController();
            if (UserController.currentUser != null)
            {
                UserController.currentUser = uc.getUser(UserController.currentUser.username, UserController.currentUser.wachtwoord);
            }
        }

        // GET: UIDashboard
        public ActionResult Index()
    {
      return View();
    }

    public ActionResult NewGrafiek(int eid, int type)
    {
      lastGrafiekVM = new WebGrafiekVM();
      lastGrafiekVM.grafiek.elements.Add(ec.GetElement(eid));
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
    }

    public ActionResult GenereerGrafiek(WebGrafiekVM g)
    {
      Element e = ec.GetElement(g.elementNaam);
      if(e != null && lastGrafiekVM.grafiek.elements.Count < 5)
      {
        lastGrafiekVM.grafiek.elements.Add(e);
      }
      g.grafiek.elements = lastGrafiekVM.grafiek.elements;
      g.grafiek.dashboards = lastGrafiekVM.grafiek.dashboards;
      g.grafiek.id = lastGrafiekVM.grafiek.id;
      lastGrafiekVM.elementNaam = null;
      lastGrafiekVM.grafiek = dc.UpdateGrafiek(g.grafiek);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
    }

    public ActionResult EditGrafiek(int grafiek_id)
    {
      lastGrafiekVM = new WebGrafiekVM();
      lastGrafiekVM.grafiek = dc.GetGrafiek(grafiek_id);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
    }

    public ActionResult SaveGrafiek()
    {
      if(!(lastGrafiekVM.grafiek.beginDate.Equals(new DateTime(0001,01,1)) || lastGrafiekVM.grafiek.eindDate.Equals(new DateTime(0001, 01, 1))))
      {
        dc.AddGrafiek(dc.GetDashboard(UserController.currentUser, PlatformController.currentDeelplatform), lastGrafiekVM.grafiek);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
      }
      
      
    }

    public ActionResult DeleteGrafiek(int grafiek_id)
    {
      dc.RemoveGrafiek(grafiek_id, dc.GetDashboard(UserController.currentUser, PlatformController.currentDeelplatform).id);
      return RedirectToAction("Index", "Home");
    }

    public ActionResult DeleteElement(int eid)
    {
      lastGrafiekVM.grafiek.elements.Remove(ec.GetElement(eid));
      lastGrafiekVM.grafiek = dc.UpdateGrafiek(lastGrafiekVM.grafiek);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
    }

    public ActionResult NewGrafiekByName(string naam)
    {
      lastGrafiekVM = new WebGrafiekVM();
      lastGrafiekVM.grafiek.elements.Add(ec.GetElement(naam));
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiekVM);
    }
  }
}