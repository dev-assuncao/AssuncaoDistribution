using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssuncaoDistribution.Models
{
    public class Products
    {
        public int Id { get; set; }
        public UnitsMeasures Measures{ get; set; }
        public int AmountProd { get; set; }
        public double PriceProd { get; set; }

        [ForeignKey("Measures")]
        public int MeasuresId { get; set; }

        public Products()
        {
        }

        public Products (int idProd, UnitsMeasures measuresId, int amountProd, double priceProd)
        {
            Id = idProd;
            Measures = measuresId;
            AmountProd = amountProd;
            PriceProd = priceProd;
        }
        
    }
}
