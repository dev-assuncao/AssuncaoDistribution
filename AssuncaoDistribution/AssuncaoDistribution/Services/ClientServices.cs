using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;
using AssuncaoDistribution.Services.Exceptions;

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


        public Client FindClient(int id)
        {
            return _clientContext.Clients.FirstOrDefault(x => x.Id == id);
        }


        public bool HasClient(int id)
        {
            return _clientContext.Clients.Any(x => x.Id == id);
        }

        public void InsertClient (Client client)
        {
            var hasClient = _clientContext.Clients.Any(x => x.CnpjOrCpf == client.CnpjOrCpf);

            if(hasClient)
            {
                throw new ApplicationException("Already client in database");
            }

            _clientContext.Clients.Add(client);

            _clientContext.SaveChanges();
        }

        public void UpdateClient (Client client)
        {
            var hasClient = _clientContext.Clients.Any(x => x.Id == client.Id);


            if (!hasClient)
            {
                throw new NotFoundException("Not find client in database to update");
            }
            _clientContext.Clients.Update(client);
            _clientContext.SaveChanges();
        }

        public void DeleteClient (Client client)
        {
            var hasClient = _clientContext.Clients.Any(x => x.Id == client.Id);

            if (!hasClient)
            {
                throw new Exception("Not find client to delete");
            }

            _clientContext.Remove(client);
            _clientContext.SaveChanges();
        }


    }
}
