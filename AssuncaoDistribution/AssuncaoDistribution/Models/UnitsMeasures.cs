using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class UnitsMeasures
    {
        public int CodUnit { get; set; }
        public string AbbreviationUnit { get; set; }
        public string Description { get; set; }


        public UnitsMeasures (int codUnit, string abbreviationUnit, string description)
        {
            CodUnit = codUnit;
            AbbreviationUnit = abbreviationUnit;
            Description = description;
        }

    }
}
