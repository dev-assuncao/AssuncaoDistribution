using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models.ViewModels;

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
    }
}
