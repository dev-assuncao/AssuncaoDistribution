using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models.ViewModels;
using AssuncaoDistribution.Models;

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
                var purchaseOrder = new PurchaseOrder { Id = purchase.PurchaseOrder.Id, PurchDate = purchase.PurchaseOrder.PurchDate, ProviderId = purchase.PurchaseOrder.ProviderId, PriceOrder = purchase.PurchaseOrder.PriceOrder };

                _purchaseOrderContext.CreatePurchaseOrder(purchaseOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

    }
}
