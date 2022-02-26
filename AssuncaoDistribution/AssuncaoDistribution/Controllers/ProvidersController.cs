using Microsoft.AspNetCore.Mvc;
using System;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models;
using AssuncaoDistribution.Services.Exceptions;
using System.Diagnostics;

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
            if (ModelState.IsValid)
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

            if (!hasProvider)
            {
                return RedirectToAction(nameof(Error), new { Message = "Provider not found", id = 404 });
            }

            var findProvider = _providerContext.FindProvider(id.Value);


            if (findProvider == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Provider can not be null, please try again", id = 400});
            }

            return View(findProvider);
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
        public IActionResult Delete(Provider provider)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _providerContext.DeleteProvider(provider);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbConcurrencyException e)
                {
                    return RedirectToAction(nameof(Error), new { id = 409, message = e.Message });
                }
                catch (NotFoundException e)
                {
                    return RedirectToAction(nameof(Error), new { id = 404, message = e.Message});
                }

            }

            return View(provider);

        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int? id, string message)
        {
            var errorModel = new ErrorViewModel()
            {
                ErrorCode = id.Value,
                Title = "An error occurred",         
                Message = message
            };

            return View(errorModel);
        }
    }
}
