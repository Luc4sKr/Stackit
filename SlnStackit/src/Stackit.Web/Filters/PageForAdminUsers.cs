using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Stackit.Domain.Entities;
using Stackit.Domain.Enums;
using Stackit.Web.Helper;

namespace Stackit.Web.Filters
{
    public class PageForAdminUsers : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userSession = context.HttpContext.Session.GetString(Session.LOGGED_USER_SESSION);

            if (string.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(userSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
                }

                if (user.Profile != ProfileEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
                }
            }
        }
    }
}
