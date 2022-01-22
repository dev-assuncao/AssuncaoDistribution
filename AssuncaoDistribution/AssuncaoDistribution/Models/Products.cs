using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssuncaoDistribution.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string NameProd { get; set; }
        public UnitsMeasures Measures{ get; set; }

        [Display(Name = "Amount")]
        public int AmountProd { get; set; }

        [Display(Name = "Price")]
   
        [DisplayFormat()]
        public double PriceProd { get; set; }

        [ForeignKey("Measures")]
        public int MeasuresId { get; set; }

        public Products()
        {
        }

        public Products (int idProd, string nameProd, UnitsMeasures measuresId, int amountProd, double priceProd)
        {
            Id = idProd;
            NameProd = nameProd;
            Measures = measuresId;
            AmountProd = amountProd;
            PriceProd = priceProd;
        }
        

        public double PriceCalc(int amount)
        {
            return amount * PriceProd;
        }
    }
}
