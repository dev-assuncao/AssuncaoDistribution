using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Services;

namespace AssuncaoDistribution.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductServices _productServices;

        public ProductsController(ProductServices context)
        {
            _productServices = context;
        }

        public IActionResult Index()
        {
            var allProducts = _productServices.AllProducts();
            return View(allProducts);
        }
    }
}
