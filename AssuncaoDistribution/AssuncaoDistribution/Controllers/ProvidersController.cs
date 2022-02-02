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
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Provider provider)
        {
            if(ModelState.IsValid)
            {
                _providerContext.CreateProvider(provider);

                return RedirectToAction(nameof(Index));
            }

            return View(provider);
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


        public IActionResult Details(int id)
        {
            var hasProv = _providerContext.HasProvider(id);

            if (hasProv)
            {
                var provider = _providerContext.FindProvider(id);

                return View(provider);
            }
            else
            {
                throw new Exception("Provider not found in database");
            }
           
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hasProv = _providerContext.HasProvider(id);

            if (hasProv)
            {
                var provider = _providerContext.FindProvider(id);

                return View(provider);
            }
            else
            {
                throw new Exception("Provider do not exist in database");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (Provider provider)
        {
            if (ModelState.IsValid)
            {
                _providerContext.DeleteProvider(provider);

                return RedirectToAction(nameof(Index));
            }

            return View(provider);

        }


    }
}
