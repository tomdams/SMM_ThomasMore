﻿using SC.BL.Domain.User;
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
      lastGrafiek.kruising = true;
      lastGrafiek.elements.Add(ec.GetElement(eid));
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
    }

    public ActionResult GenereerGrafiek(Grafiek g)
    {
      Element e = ec.GetElement(g.x_as);
      if(e != null)
      {
        lastGrafiek.elements.Add(e);
      }
      g.elements = lastGrafiek.elements;
      g.dashboards = lastGrafiek.dashboards;
      g.id = lastGrafiek.id;
      g.kruising = lastGrafiek.kruising;
      lastGrafiek = dc.UpdateGrafiek(g);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
    }

    public ActionResult EditGrafiek(int grafiek_id)
    {
      lastGrafiek = dc.GetGrafiek(grafiek_id);
      return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
    }

    public ActionResult SaveGrafiek()
    {
      if(!(lastGrafiek.beginDate.Equals(new DateTime(0001,01,1)) || lastGrafiek.eindDate.Equals(new DateTime(0001, 01, 1))))
      {
        dc.AddGrafiek(dc.GetDashboard(UserController.currentUser, PlatformController.currentDeelplatform), lastGrafiek);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View("~/Views/UIDashboard/NewGrafiek.cshtml", lastGrafiek);
      }
      
      
    }

    public ActionResult DeleteGrafiek(int grafiek_id)
    {
      dc.RemoveGrafiek(grafiek_id, dc.GetDashboard(UserController.currentUser, PlatformController.currentDeelplatform).id);
      return RedirectToAction("Index", "Home");
    }
  }
}