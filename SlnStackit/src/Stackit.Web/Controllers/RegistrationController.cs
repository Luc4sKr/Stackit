using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.Entities;
using Stackit.Domain.IServices;
using Stackit.Web.Models;
using Stackit.Domain.Enums;
using Stackit.Domain.DTO;

namespace Stackit.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Helper.ISession _session;
        private readonly IUserService _userService;

        public RegistrationController(Helper.ISession session,
                                      IUserService userService)
        {
            _session = session;
            _userService = userService;
        }


        public IActionResult Sigin()
        {
            if (_session.FetchUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Signup()
        {
            if (_session.FetchUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Exit()
        {
            _session.RemoveUserSession();
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public async Task<IActionResult> Enter(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDTO user = await _userService.FindByUsernameAndPassword(userDTO.username, userDTO.password);

                    if (user != null)
                    {
                        _session.CreateUserSession(user.MapToEntity());
                        return RedirectToAction("Index", "Home");
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.Save(userDTO);
                    return RedirectToAction("Index", "Home");
                }

                return View(userDTO);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
