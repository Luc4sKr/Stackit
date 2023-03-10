using Stackit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindByUsernameAndPassword(string username, string password);
    }
}
