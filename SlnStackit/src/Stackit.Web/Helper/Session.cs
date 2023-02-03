using Newtonsoft.Json;
using Stackit.Domain.DTO;
using Stackit.Domain.Entities;

namespace Stackit.Web.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;
        public const string LOGGED_USER_SESSION = "loggedUserSession";

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSession(User user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString(LOGGED_USER_SESSION, value);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove(LOGGED_USER_SESSION);
        }

        public UserDTO FetchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString(LOGGED_USER_SESSION);

            if (string.IsNullOrEmpty(userSession)) return null;

            User user = JsonConvert.DeserializeObject<User>(userSession);
            UserDTO userDTO = new UserDTO();
            userDTO = userDTO.MapToDTO(user);

            return userDTO;
        }
    }
}
