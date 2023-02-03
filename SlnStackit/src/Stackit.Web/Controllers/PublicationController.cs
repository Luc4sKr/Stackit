using Microsoft.AspNetCore.Mvc;
using Stackit.Domain.DTO;
using Stackit.Domain.IServices;
using Stackit.Web.Helper;

namespace Stackit.Web.Controllers
{
    public class PublicationController : Controller
    {
        private readonly Helper.ISession _session;
        private readonly IPublicationService _publictionService;

        public PublicationController(IPublicationService publicationService,
                                    Helper.ISession session)
        {
            _publictionService = publicationService;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            /*UserDTO userDTO = _session.FetchUserSession();
            ViewData["user"] = userDTO;*/

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(PublicationDTO publicationDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    publicationDTO.userId = _session.FetchUserSession().id;
                    await _publictionService.Save(publicationDTO);
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
