using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class ClientServices
    {
        private readonly AssuncaoDistributionContext _clientContext;

        public ClientServices(AssuncaoDistributionContext context)
        {
            _clientContext = context;
        }


        public ICollection<Client> AllClients()
        {
            return _clientContext.Clients.ToList();
        }
    }
}
