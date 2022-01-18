using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssuncaoDistribution.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public Client Clients { get; set; }
        public DateTime DateOrder { get; set; }

        public double PriceSale { get; set; }

        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        
        public SalesOrder()
        {
        }

        public SalesOrder (int codOrder, Client client, DateTime date, double priceSale)
        {
            Id = codOrder;
            Clients = client;
            DateOrder = date;
            PriceSale = priceSale;
        }

    }
}
