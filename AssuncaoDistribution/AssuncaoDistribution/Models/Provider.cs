using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public int CnpjOrCpfProv { get; set; }
        public string AddresProv { get; set; }
        public string DistrictProv { get; set; }
        public string CepProv { get; set; }
        public string CityProv { get; set; }
        public int PhoneProv { get; set; }
        public int Fax { get; set; }
        public string EmailProv { get; set; }
        public string Contact { get; set; }

        public Provider()
        {
        }

        public Provider(int codProv, string corporateName, string fantasyName, int cnpjOrCpfProv, string addresProv, string districtProv, string cepProv, string cityProv, int phoneProv, int fax, string emailProv, string contact)
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
        }




    }
}
