using Microsoft.AspNetCore.Mvc;

namespace Stackit.Web.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
