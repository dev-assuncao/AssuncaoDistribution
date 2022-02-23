using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssuncaoDistribution.Models
{
    public class Client
    {
        private const string V = "{0:00000-000}";

        public int Id { get; set; }

        [Required(ErrorMessage = "Please inform your Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please inform your Contact")]
        [Display(Name = "Contact")]
        public string ContactCli { get; set; }

        [Required(ErrorMessage = "Please inform your Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Please fill the field Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please fill the field CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Please fill the field City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please fill the field Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill the field Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Fill the field UF ")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "Please Fill the field CPF")]
        [Display(Name= "CPF")]
        public string CnpjOrCpf { get; set; }

        public Client()
        {
        }

        public Client (int idCli, string name, string contactCli, DateTime birthday, string address, string cep, string city, string email, string phone, string uf, string cnpjOrCpf)
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
