using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class SalesOrder
    {
        public int CodOrder { get; set; }
        public Client CodClient { get; set; }
        public double PriceOrder { get; set; }

        public SalesOrder (int codOrder, Client codClient, double priceOrder)
        {
            CodOrder = codOrder;
            CodClient = codClient;
            PriceOrder = priceOrder;
        }

    }
}
