using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        public String Description { get; set; }

        public String PictureUrl { get; set; }

        public Decimal Price { get; set; }

        public int BrandId { get; set; }

        public ProductBrand Brand { get; set; }

        public int CategoryId { get; set; }

        public ProductCategory Category { get; set; }
    }
}
