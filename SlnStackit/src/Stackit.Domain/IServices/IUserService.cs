using Stackit.Domain.DTO;
using Stackit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.IServices
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<UserDTO> FindByUsernameAndPassword(string username, string password);
    }
}
