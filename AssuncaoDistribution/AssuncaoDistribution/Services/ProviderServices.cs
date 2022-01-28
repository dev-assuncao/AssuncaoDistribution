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


        public Provider FindProvider(int id)
        {
            return _providerContext.Providers.FirstOrDefault(x => x.Id == id);
        }

        public bool HasProvider(int id)
        {
            return _providerContext.Providers.Any(x => x.Id == id);
        }


        public void UpdateProvider (Provider provider)
        {
            var hasProvider = _providerContext.Providers.Any(x => x.Id == provider.Id);

            if (!hasProvider)
            {
                throw new Exception("Provider not found in database");
            }

            _providerContext.Update(provider);

            _providerContext.SaveChanges();
        }



    }
}
