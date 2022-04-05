using Microsoft.AspNetCore.Mvc;
using AssuncaoDistribution.Services;

namespace AssuncaoDistribution.Controllers
{
    public class PurchaseOrdemItemsController : Controller
    {
        private readonly PurchaseOrderItemsServices _purchaseItemsContext;
        private readonly PurchaseOrderServices _purchaseOrderContext;

        public PurchaseOrdemItemsController(PurchaseOrderItemsServices itemContext, PurchaseOrderServices orderContext)
        {
            _purchaseItemsContext = itemContext;
            _purchaseOrderContext = orderContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* implementing yet
        [HttpGet]
        public IActionResult Create(int id)
        {
            var purchaseOrder = _purchaseOrderContext.FindPurchaseOrder(id);

        }*/
    }
}