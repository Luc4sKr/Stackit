using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.DTO;
using Stackit.Domain.Entities;
using Stackit.Domain.IServices;
using Stackit.Web.Helper;

namespace Stackit.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Helper.ISession _session;

        public UserController(IUserService userService, 
                              Helper.ISession session)
        {
            _userService = userService;
            _session = session;
        }

        public IActionResult Index()
        {
            User user = _session.FetchUserSession();

            return View(user);
        }
    }
}
