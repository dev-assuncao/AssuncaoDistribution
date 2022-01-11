using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class Client
    {
        public int CodCli { get; set; }
        public string Name { get; set; }
        public string ContactCli { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int CnpjOrCpf { get; set; }


        public Client (int codCli, string name, string contactCli, DateTime birthday, string address, int cep, string city, string email, int phone, int cnpjOrCpf)
        {
            CodCli = codCli;
            Name = name;
            ContactCli = contactCli;
            Birthday = birthday;
            Address = address;
            Cep = cep;
            City = city;
            Email = email;
            Phone = phone;
            CnpjOrCpf = cnpjOrCpf;
        }

    }
}
