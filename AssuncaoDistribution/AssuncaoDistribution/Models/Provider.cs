using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssuncaoDistribution.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Display(Name = "Corporate Name")]
        public string CorporateName { get; set; }

        [Display(Name = "Fantasy Name")]
        public string FantasyName { get; set; }


        [Display(Name = "CNPJ or CPF")]
        public long CnpjOrCpfProv { get; set; }

        [Display(Name = "Addres")]
        public string AddresProv { get; set; }

        [Display(Name = "District")]
        public string DistrictProv { get; set; }

        [Display(Name = "CEP")]
        public int CepProv { get; set; }

        [Display(Name = "City")]
        public string CityProv { get; set; }

        [Display(Name = "Phone")]
        public int PhoneProv { get; set; }
        public int Fax { get; set; }

        [Display(Name = "Email")]
        public string EmailProv { get; set; }
        public string Contact { get; set; }
        public double Portage { get; set; }

        public Provider()
        {
        }

        public Provider(int codProv, string corporateName, string fantasyName, long cnpjOrCpfProv, string addresProv, string districtProv, int cepProv, string cityProv, int phoneProv, int fax, string emailProv, string contact, double portage)
        {
            Id = codProv;
            CorporateName = corporateName;
            FantasyName = fantasyName;
            CnpjOrCpfProv = cnpjOrCpfProv;
            AddresProv = addresProv;
            DistrictProv = districtProv;
            CepProv = cepProv;
            CityProv = cityProv;
            PhoneProv = phoneProv;
            Fax = fax;
            EmailProv = emailProv;
            Contact = contact;
            Portage = portage;
        }




    }
}
