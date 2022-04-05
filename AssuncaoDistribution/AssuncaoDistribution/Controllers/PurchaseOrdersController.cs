using Microsoft.AspNetCore.Mvc;
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



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(PurchaseOrdersViewModel model)
        {
            if (ModelState.IsValid)
            {

                var purchase = new PurchaseOrder
                {
                    Id = model.PurchaseOrder.Id,
                    ProviderId = model.PurchaseOrder.ProviderId,
                    PurchDate = model.PurchaseOrder.PurchDate,
                    PriceOrder = model.PurchaseOrder.PriceOrder
                };

                try
                {
                    _purchaseOrderContext.UpdatePurchaseOrder(purchase);
                    return RedirectToAction(nameof(Index));
                }
                catch(DbConcurrencyException e)
                {
                    throw new DbConcurrencyException(e.Message);
                }
                catch(NotFoundException e)
                {
                    throw new NotFoundException(e.Message);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var purchase = _purchaseOrderContext.FindPurchaseOrder(id);

            return View(purchase);
        }


        [HttpPost]
        public IActionResult Delete(int id, PurchaseOrder purchase)
        {
            if (id != purchase.Id)
            {
                throw new NotFoundException("Id mismatch");
            }


            try
            {
                var findPurch = _purchaseOrderContext.FindPurchaseOrder(id);

                _purchaseOrderContext.DeletePurchaseOrder(findPurch);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
