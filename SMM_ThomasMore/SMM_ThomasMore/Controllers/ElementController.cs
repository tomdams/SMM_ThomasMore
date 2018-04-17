using SMM_ThomasMore.BL;
using System.Web.Mvc;

namespace SMM_ThomasMore.Controllers
{
  public class ElementController : Controller
    {
    private IElementManager mgr;

    public ElementController()
    { }

    public void genereerAlerts()
    {
      mgr = new ElementManager();
    }


    // GET: Element
    public ActionResult Index()
        {
            return View();
        }
    }
}