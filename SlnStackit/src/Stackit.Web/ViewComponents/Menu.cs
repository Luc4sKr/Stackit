using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stackit.Domain.DTO;
using Stackit.Domain.Entities;
using Stackit.Web.Helper;

namespace Stackit.Web.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString(Session.LOGGED_USER_SESSION);

            //if (string.IsNullOrEmpty(userSession)) return View("LoggedOut");

            User user = new User();

            if (string.IsNullOrEmpty(userSession))
            {
                user.Profile = Domain.Enums.ProfileEnum.LoggedOut;
            }
            else
            {
                user = JsonConvert.DeserializeObject<User>(userSession);
            }
            
            UserDTO userDTO = new UserDTO();
            userDTO = userDTO.MapToDTO(user);

            return View(userDTO);
        }
    }
}
