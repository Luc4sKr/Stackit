using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.DTO;
using Stackit.Domain.IServices;
using Microsoft.AspNetCore.Components;
using Stackit.Web.Filters;
using Stackit.Application.Services.SQLServerServices;

namespace Stackit.Web.Controllers
{
    [PageForLoggedUsers]
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

            if (userDTO == null)
            {
                return RedirectToAction("Index", "Home");
            }

            userDTO.publications = _publicationService.FindAllByUserId(userDTO.id);

            return View(userDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserDTO userDTO = await _userService.FindById(id);
            return View(userDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.Update(userDTO);
                    return RedirectToAction("Index", "User");
                }

                return RedirectToAction("Index", "User");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "User");
            }
        }
    }
}
