using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class ProductServices
    {

        private readonly AssuncaoDistributionContext _productContext;

        public ProductServices(AssuncaoDistributionContext context)
        {
            _productContext = context;
        }


        public ICollection<Products> AllProducts ()
        {
            return _productContext.Products.ToList();    
        }

        public Products FindProduct(int id)
        {
            return _productContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public bool HasProduct(int id)
        {
            return _productContext.Products.Any(product => product.Id == id);
        }


        public void InsertProduct(Products product)
        {
            bool hasProduct = _productContext.Products.Any(obj => obj.NameProd == product.NameProd);

            if (hasProduct)
            {
                throw new Exception("Database has product");
            }

            _productContext.Products.Add(product);
            _productContext.SaveChanges();
        }


        public void UpdateProduct (Products product)
        {
            bool hasProduct = _productContext.Products.Any(x => x.Id == product.Id);

            if (!hasProduct)
            {
                throw new Exception("Product not found in database");
            }

            _productContext.Update(product);
            _productContext.SaveChanges();
        }


        public void DeleteProduct(Products product)
        {
            bool hasProduct = _productContext.Products.Any(x => x.Id == product.Id);

            if (!hasProduct)
            {
                throw new Exception("Product not found in database");
            }

            _productContext.Remove(product);
            _productContext.SaveChanges();
        }
    }
}
