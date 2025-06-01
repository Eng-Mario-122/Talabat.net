using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.RepositoryContract;
using Talabat.core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;
        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //if(typeof(T)==typeof(Product))
         //      return (IEnumerable<T>) await _dbcontext.Set<Product>().Include(p => p.Category).Include(p => p.Brand).ToListAsync();
            return await _dbcontext.Set<T>().ToListAsync();
        }

      
        public async Task<T?> GetAsync(int id)
        {
            //if (typeof(T)==typeof(Product))
            //    return await _dbcontext.Set<Product>().Include(p => p.Category).Include(p => p.Brand).FirstOrDefaultAsync()as T;
            return await _dbcontext.Set<T>().FindAsync(id);     
        }


        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>(),spec).ToListAsync();
        }

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), spec).FirstOrDefaultAsync();


        }
    }
}
