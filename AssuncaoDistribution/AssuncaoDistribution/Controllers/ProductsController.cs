using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Services;
using AssuncaoDistribution.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssuncaoDistribution.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                var result = _productServices.HasProduct(products.Id);

                _productServices.InsertProduct(products);

                return RedirectToAction(nameof(Index));
            }


            return View(products);
            
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id mismatch");
            }

            var hasProduct = _productServices.HasProduct(id.Value);

            if (hasProduct)
            {
                var product = _productServices.FindProduct(id.Value);

                return View(product);
            }
            else
            {
                throw new Exception("Id not found");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Products product)
        {
            if (ModelState.IsValid)
            {
                _productServices.UpdateProduct(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        
        public IActionResult Details(int? id)
        {
            var hasProduct = _productServices.HasProduct(id.Value);

            if(hasProduct)
            {
                var product = _productServices.FindProduct(id.Value);

                return View(product);
            }
            else
            {
                throw new Exception("Product not found in database");
            }


        }


        public IActionResult Delete(int id)
        {
            bool findProduct = _productServices.HasProduct(id);

            if (findProduct)
            {
                var product = _productServices.FindProduct(id);

                return View(product);
            }
            else
            {
                throw new Exception("Product not found in database or system");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id, Products product)
        {
            if(ModelState.IsValid)
            {
                _productServices.DeleteProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}
