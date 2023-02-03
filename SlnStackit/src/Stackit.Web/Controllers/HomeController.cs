using Microsoft.AspNetCore.Mvc;
using Stackit.Web.Models;
using System.Diagnostics;
using Stackit.Domain.Enums;

namespace Stackit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Helper.ISession _session;

        public HomeController(ILogger<HomeController> logger,
                              Helper.ISession session)
        {
            _logger = logger;
            _session = session;
        }

        public IActionResult Index()
        {
            /*var user = _session.FetchUserSession();

            if (user == null)
            {
                ViewData["Layout"] = "_LayoutLoggedOut";
            }
            else if (user.Profile == ProfileEnum.Admin)
            {
                ViewData["Layout"] = "_LayoutAdmin";
            }

            else if (user.Profile == ProfileEnum.Default)
            {
                ViewData["Layout"] = "_LayoutLoggedOut";
            }*/

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}