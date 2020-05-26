using System.Web.Mvc;

namespace triluatsoft.tls.Web.Controllers
{
    public class HomeController : tlsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}