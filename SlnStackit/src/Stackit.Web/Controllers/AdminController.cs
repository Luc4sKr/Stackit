using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.IServices;
using Stackit.Web.Filters;

namespace Stackit.Web.Controllers
{
    [PageForAdminUsers]
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

        public IActionResult Dashboard()
        {
            
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var userDTO = _userService.FindAll();
            return View(userDTO);
        }

        public async Task<IActionResult> Publications()
        {
            var publicationDTO = _publicationService.FindAll();
            return View(publicationDTO);
        }
    }
}
