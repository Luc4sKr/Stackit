using Microsoft.AspNetCore.Mvc;
using Stackit.Web.Models;
using System.Diagnostics;
using Stackit.Domain.Enums;
using Stackit.Domain.DTO;
using Stackit.Domain.IServices;

namespace Stackit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Helper.ISession _session;
        private readonly IPublicationService _publicationService;

        public HomeController(ILogger<HomeController> logger,
                              Helper.ISession session,
                              IPublicationService publicationService)
        {
            _logger = logger;
            _session = session;
            _publicationService = publicationService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_publicationService.FindAllDescending());
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