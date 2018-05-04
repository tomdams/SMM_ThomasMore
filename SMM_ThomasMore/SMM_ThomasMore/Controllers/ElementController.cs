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

    public void volgElement(int element_id, AlertType type, int user_id)
    {
      mgr.volgElement(element_id, type, user_id);
    }

    public void politiciInlezen()
    {
      mgr.politiciInlezen();
    }

  }
}