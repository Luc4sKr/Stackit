using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stackit.Domain.Entities;
using Stackit.Web.Helper;

namespace Stackit.Web.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString(Session.LOGGED_USER_SESSION);

            if (string.IsNullOrEmpty(userSession)) return View("LoggedOut");

            User user = JsonConvert.DeserializeObject<User>(userSession);

            return View(user);
        }
    }
}
