using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Services;

namespace AssuncaoDistribution.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly ProviderServices _providerContext;

        public ProvidersController(ProviderServices provider)
        {
            _providerContext = provider;
        }

        public IActionResult Index()
        {
            var allProviders = _providerContext.AllProviders();

            return View(allProviders);
        }
    }
}
