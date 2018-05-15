using SC.BL.Domain.User;
using SMM_ThomasMore.Controllers;
using SMM_ThomasMore.Domain;
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
    private static Grafiek lastGrafiek;

    // GET: UIDashboard
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult NewGrafiek(int eid)
    {
      lastGrafiek = new Grafiek();
      lastGrafiek.element = ec.GetElement(eid);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
    }

    public ActionResult GenereerGrafiek(Grafiek g)
    {
      g.element = lastGrafiek.element;
      lastGrafiek = dc.UpdateGrafiek(g);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
    }

    public ActionResult SaveGrafiek()
    {
      dc.AddGrafiek(dc.GetDashboard(UserController.currentUser), lastGrafiek);
      return View("~/Views/Home/Index.cshtml");
    }
  }
}