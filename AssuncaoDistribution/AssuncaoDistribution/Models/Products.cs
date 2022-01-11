using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class Products
    {
        public int CodProd { get; set; }
        public Classification CodClassi { get; set; }
        public UnitsMeasures CodMeasures { get; set; }
        public int AmountProd { get; set; }
        public double PriceProd { get; set; }

        public Products (int codProd, Classification codClassi, UnitsMeasures codMeasures, int amountProd, double priceProd)
        {
            CodProd = codProd;
            CodClassi = codClassi;
            UnitsMeasures = codMeasures;
            AmountProd = amountProd;
            PriceProd = priceProd;
        }
        
    }
}
