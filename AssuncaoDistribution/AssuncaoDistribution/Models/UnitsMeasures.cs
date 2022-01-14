using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class UnitsMeasures
    {
        public int Id { get; set; }
        public string AbbreviationUnit { get; set; }
        public string Description { get; set; }


        public UnitsMeasures()
        {
        }

        public UnitsMeasures (int codUnit, string abbreviationUnit, string description)
        {
            Id = codUnit;
            AbbreviationUnit = abbreviationUnit;
            Description = description;
        }

    }
}
