using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;
using AssuncaoDistribution.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;

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


        public void CreateProvider(Provider provider)
        {
            var hasProv = _providerContext.Providers.Any(x => x.CorporateName == provider.CorporateName);

            if (hasProv)
            {
                throw new ApplicationException("Provider already register in database");
            }

            try
            {
                _providerContext.Add(provider);
                _providerContext.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }


        public void UpdateProvider (Provider provider)
        {
            var hasProvider = _providerContext.Providers.Any(x => x.Id == provider.Id);

            if (!hasProvider)
            {
                throw new NotFoundException("Provider not found in database");
            }

            try
            {
                _providerContext.Update(provider);
                _providerContext.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        public void DeleteProvider (Provider provider)
        {
            var hasProv = _providerContext.Providers.Any(x => x.Id == provider.Id);

            if (!hasProv)
            {
                throw new NotFoundException("Provider do not find in database");
            }

            try
            {
                _providerContext.Remove(provider);
                _providerContext.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
