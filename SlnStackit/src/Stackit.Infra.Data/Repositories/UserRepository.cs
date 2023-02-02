using Stackit.Domain.Entities;
using Stackit.Domain.IRepositories;
using Stackit.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SQLServerContext _context;

        public UserRepository(SQLServerContext context) : base(context) 
        {
            _context = context;
        }
    }
}
