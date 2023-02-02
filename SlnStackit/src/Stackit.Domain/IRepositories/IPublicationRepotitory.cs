using Stackit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.IRepositories
{
    public interface IPublicationRepotitory : IBaseRepository<Publication>
    {
        IQueryable<Publication> FindAllByUserId(int userId);
    }
}
