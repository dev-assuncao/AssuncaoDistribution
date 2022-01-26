using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class ProviderServices
    {
        private readonly AssuncaoDistributionContext _providerContext;

        public ProviderServices(AssuncaoDistributionContext context)
        {
            _providerContext = context;
        }


        public ICollection<Provider> AllProviders()
        {
            return _providerContext.Providers.ToList();
        }




    }
}
