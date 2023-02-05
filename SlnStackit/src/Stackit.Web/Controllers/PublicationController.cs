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
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            PublicationDTO publicationDTO = await _publictionService.FindById(id);
            return View(publicationDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _publictionService.Delete(id);
            return RedirectToAction("Publications", "Admin");
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

        [HttpPost]
        public async Task<IActionResult> Edit(PublicationDTO publicationDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _publictionService.Update(publicationDTO);
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
