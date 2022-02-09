using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssuncaoDistribution.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Contact")]
        public string ContactCli { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Uf { get; set; }
        [Display(Name= "CNPJ or CPF")]
        public long CnpjOrCpf { get; set; }

        public Client()
        {
        }

        public Client (int idCli, string name, string contactCli, DateTime birthday, string address, int cep, string city, string email, int phone, string uf, long cnpjOrCpf)
        {
            Id = idCli;
            Name = name;
            ContactCli = contactCli;
            Birthday = birthday;
            Address = address;
            Cep = cep;
            City = city;
            Uf = uf;
            Email = email;
            Phone = phone;
            CnpjOrCpf = cnpjOrCpf;
        }

    }
}
