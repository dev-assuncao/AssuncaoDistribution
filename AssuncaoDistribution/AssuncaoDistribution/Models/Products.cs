using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class Products
    {
        public int CodProd { get; set; }
        public UnitsMeasures CodMeasures { get; set; }
        public int AmountProd { get; set; }
        public double PriceProd { get; set; }

        public Products (int codProd, UnitsMeasures codMeasures, int amountProd, double priceProd)
        {
            CodProd = codProd;
            CodMeasures = codMeasures;
            AmountProd = amountProd;
            PriceProd = priceProd;
        }
        
    }
}
