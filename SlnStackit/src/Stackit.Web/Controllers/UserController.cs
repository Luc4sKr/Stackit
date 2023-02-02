using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.IServices;

namespace Stackit.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.FindAll());
        }
    }
}
