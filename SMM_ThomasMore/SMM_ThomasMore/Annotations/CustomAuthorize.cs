using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMM_ThomasMore.Annotations
{
  public class CustomAuthorize : AuthorizeAttribute
  {
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
      if (this.AuthorizeCore(filterContext.HttpContext))
      {
        base.OnAuthorization(filterContext);
      }
      else
      {
        this.HandleUnauthorizedRequest(filterContext);
      }
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
      filterContext.Result = new RedirectResult("~/Error/UnauthorizedError");
    }
  }
}