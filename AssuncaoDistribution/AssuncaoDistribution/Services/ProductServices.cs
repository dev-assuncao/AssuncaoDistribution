using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class ProductServices
    {

        private readonly AssuncaoDistributionContext _productContext;

        public ProductServices(AssuncaoDistributionContext context)
        {
            _productContext = context;
        }


        public ICollection<Products> AllProducts ()
        {
            return _productContext.Products.ToList();    
        }

    }
}
