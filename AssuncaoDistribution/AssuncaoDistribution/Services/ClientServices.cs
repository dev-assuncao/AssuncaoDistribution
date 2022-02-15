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


        public Client FindClient(int id)
        {
            return _clientContext.Clients.FirstOrDefault(x => x.Id == id);
        }


        public bool HasClient(string cpfOrCnpj)
        {
            return _clientContext.Clients.Any(x => x.CnpjOrCpf == cpfOrCnpj);
        }

        public void InsertClient (Client client)
        {
            var hasClient = _clientContext.Clients.Any(x => x.CnpjOrCpf == client.CnpjOrCpf);

            if(hasClient)
            {
                throw new Exception("Already client in database");
            }

            _clientContext.Clients.Add(client);

            _clientContext.SaveChanges();
        }



    }
}
