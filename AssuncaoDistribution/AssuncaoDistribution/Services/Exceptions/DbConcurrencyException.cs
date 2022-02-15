using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Services.Exceptions
{
    public class DbConcurrencyException : ArgumentException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }

    }
}
