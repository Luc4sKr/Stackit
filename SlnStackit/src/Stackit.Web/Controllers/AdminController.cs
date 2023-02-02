using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.IServices;
using Stackit.Web.Filters;

namespace Stackit.Web.Controllers
{
    //[PageForAdminUsers]
    //[Route("admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPublicationService _publicationService;

        public AdminController(IUserService userService,
                               IPublicationService publicationService)
        {
            _userService = userService;
            _publicationService = publicationService;
        }

        //[Route("dashboard")]
        public IActionResult Dashboard()
        {
            
            return View();
        }
    }
}
