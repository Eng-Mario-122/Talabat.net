using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Specifications;

namespace Talabat.Repository
{
    public class SpecificationEvaluator<T>where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
        {
            var query = inputQuery;
            if(spec.Criteria is not null)
                query=query.Where(spec.Criteria);
            query=spec.Includes.Aggregate(query,(currentQuery,includeExpression)=>currentQuery.Include(includeExpression));

            return query;
        }

    }

}
