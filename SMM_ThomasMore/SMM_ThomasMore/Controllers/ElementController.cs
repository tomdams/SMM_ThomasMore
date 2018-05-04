using SMM_ThomasMore.BL;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Controllers
{
  public class ElementController
  {

    private IElementManager mgr;

    public ElementController()
    {
      mgr = new ElementManager();
    }

    public void volgElement(string naam, AlertType type, User user)
    {
      mgr.volgElement(naam, type, user);
    }

    public void politiciInlezen()
    {
      mgr.politiciInlezen();
    }

  }
}