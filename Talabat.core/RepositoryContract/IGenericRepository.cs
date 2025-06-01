using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.RepositoryContract
{
    public interface IGenericRepository<T>where T : BaseEntity
    {
       Task <T> GetAsync(int id);
        Task <IEnumerable<T>> GetAllAsync();
    }
}
