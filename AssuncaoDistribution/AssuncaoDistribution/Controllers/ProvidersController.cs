using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models;


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


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var hasProvider = _providerContext.HasProvider(id.Value);

            if (hasProvider)
            {
                var findProvider = _providerContext.FindProvider(id.Value);

                return View(findProvider);
            }
            else
            {
                throw new Exception("Not exists provider in database");
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Provider provider)
        {
            if (ModelState.IsValid)
            {
                _providerContext.UpdateProvider(provider);

                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }
    }
}
