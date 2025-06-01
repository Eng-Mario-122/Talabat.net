using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Specifications;


namespace Talabat.core.ProductSpecs
{
    public class ProductWithBrandAndCategory:BaseSpecification<Product>
    {
        public ProductWithBrandAndCategory()
            :base ()
            { 
            Includes.Add(P=>P.Brand);
            Includes.Add(P=>P.Category);

        }

        public ProductWithBrandAndCategory(int id)
            : base(p=>p.Id==id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);

        }
    }
}
