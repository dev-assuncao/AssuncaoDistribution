using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AssuncaoDistribution.Services;

namespace AssuncaoDistribution.Controllers
{

    public class PurchaseOrdersController : Controller
    {
        private readonly PurchaseOrderServices _purchaseOrderContext;

        public PurchaseOrdersController(PurchaseOrderServices purchase)
        {
            _purchaseOrderContext = purchase;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var findAll = _purchaseOrderContext.FindAllPurchaseOrders();
            return View(findAll);
        }
    }
}
