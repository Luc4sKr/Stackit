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
        private readonly IPublicationService _publicationService;
        private readonly Helper.ISession _session;

        public UserController(IUserService userService,
                              IPublicationService publicationService,
                              Helper.ISession session)
        {
            _userService = userService;
            _publicationService = publicationService;
            _session = session;
        }

        public IActionResult Index()
        {
            UserDTO userDTO = _session.FetchUserSession();
            userDTO.publications = _publicationService.FindAllByUserId(userDTO.id);

            return View(userDTO);
        }
    }
}
