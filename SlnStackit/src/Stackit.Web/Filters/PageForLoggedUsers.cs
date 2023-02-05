using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stackit.Domain.Entities;
using Stackit.Domain.Enums;
using Stackit.Web.Helper;

namespace Stackit.Web.Filters
{
    public class PageForLoggedUsers : ActionFilterAttribute
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
            }
        }
    }
}
