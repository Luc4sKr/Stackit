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
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepotitory
    {
        private readonly SQLServerContext _context;

        public PublicationRepository(SQLServerContext context) : base(context) 
        {
            _context = context;
        }

        public IQueryable<Publication> FindAllByUserId(int userId)
        {
            return _context.Set<Publication>().Where(publication => publication.UserId == userId);
        }
    }
}
