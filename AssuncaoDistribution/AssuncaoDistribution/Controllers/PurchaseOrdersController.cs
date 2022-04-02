using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models.ViewModels;
using AssuncaoDistribution.Models;
using AssuncaoDistribution.Services.Exceptions;

namespace AssuncaoDistribution.Controllers
{

    public class PurchaseOrdersController : Controller
    {
        private readonly PurchaseOrderServices _purchaseOrderContext;
        private readonly ProviderServices _providersContext;

        public PurchaseOrdersController(PurchaseOrderServices purchase, ProviderServices provider)
        {
            _purchaseOrderContext = purchase;
            _providersContext = provider;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var purchase = _purchaseOrderContext.AllPurchaseOrders();
            return View(purchase);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var provider = _providersContext.AllProviders();

            PurchaseOrdersViewModel viewModel = new PurchaseOrdersViewModel { Providers = provider };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PurchaseOrdersViewModel purchase)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var purchaseOrder = new PurchaseOrder { Id = purchase.PurchaseOrder.Id, PurchDate = purchase.PurchaseOrder.PurchDate, ProviderId = purchase.PurchaseOrder.ProviderId, PriceOrder = purchase.PurchaseOrder.PriceOrder };

                    _purchaseOrderContext.CreatePurchaseOrder(purchaseOrder);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbConcurrencyException e)
                {
                    throw new DbConcurrencyException(e.Message);
                }

            }
            return View(purchase);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findPurchase = _purchaseOrderContext.FindPurchaseOrder(id);

            if (findPurchase != null)
            {
                var allProviders = _providersContext.AllProviders();

                var viewModel = new PurchaseOrdersViewModel { Providers = allProviders, PurchaseOrder = findPurchase };


                return View(viewModel);
            }
            else
            {
                throw new NotFoundException("Purchase Order not found in Database");
            }
        }


    }
}
