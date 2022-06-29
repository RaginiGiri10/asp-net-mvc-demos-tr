using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVCApp.Repository
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = null;
            using(ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                products = new List<Product>();
                products = productDBEntities.Products.ToList();
            }

            return products;
        }


        public bool AddProduct(Product product)
        {
            bool isProductAdded = false;
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                productDBEntities.Products.Add(product);
                productDBEntities.SaveChanges();
                isProductAdded = true;
            }

            return isProductAdded;
        }


        public Product GetProductById(int id)
        {
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                var existingProduct = productDBEntities.Products.FirstOrDefault(x => x.Id == id);
                return existingProduct;
            }
        }

        public void DeleteProduct(int id)
        {
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                var existingProduct = productDBEntities.Products.FirstOrDefault(x => x.Id == id);
                productDBEntities.Products.Remove(existingProduct);
                productDBEntities.SaveChanges();
            }
        }

        public void UpdateProduct(int id, Product product)
        {
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                var existingProduct = productDBEntities.Products.FirstOrDefault(x => x.Id == id);
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductOrigin = product.ProductOrigin;
                existingProduct.ProductPrice = product.ProductPrice;
                productDBEntities.SaveChanges();
            }
        }
    }
}