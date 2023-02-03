using Stackit.Domain.DTO;
using Stackit.Domain.Entities;

namespace Stackit.Web.Helper
{
    public interface ISession
    {
        void CreateUserSession(User user);
        void RemoveUserSession();
        UserDTO FetchUserSession();
    }
}
