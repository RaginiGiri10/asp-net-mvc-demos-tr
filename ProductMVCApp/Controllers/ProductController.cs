using ProductMVCApp.Repository;
using ProductMVCApp.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProductMVCApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

       
        public ActionResult Index()
        {
            

            var productRepository = new ProductRepository();
            var products = productRepository.GetAllProducts();
            List<ProductViewModel> productList = new List<ProductViewModel>();

            foreach (var product in products)
            {
                //1. Create an object of ProductViewModel

                var productViewModel = new ProductViewModel();

                //2. Assign the Product values to the product view model object
                productViewModel.Id = product.Id;
                productViewModel.Name = product.ProductName;
                productViewModel.Amount = product.ProductPrice;
                productViewModel.Origin = product.ProductOrigin;

                //3. Add the productviewModel to the list
                productList.Add(productViewModel);
            }

            return View(productList);

        }

        public ActionResult Create()
        {
            int x = 5;
            int y = 0;
            int z = x / y;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var productRepository = new ProductRepository();
                var product = new Product
                {
                    ProductName = createViewModel.ProductName,
                    ProductOrigin = createViewModel.ProductOrigin,
                    ProductPrice = createViewModel.ProductPrice
                };

                bool isProductAdded = productRepository.AddProduct(product);

                if (isProductAdded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(createViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetProductById(id);
            var deleteProductViewModel = new DeleteProductViewModel
            {
                Id = product.Id,
                Name = product.ProductName,
                Amount = product.ProductPrice,
                Origin = product.ProductOrigin
            };
            return View(deleteProductViewModel);
        }
        
        [HttpPost]    
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(DeleteProductViewModel model)
        {
            var productRepository = new ProductRepository();
            productRepository.DeleteProduct(3);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetProductById(id);
            var editProductViewModel = new EditProductViewModel
            { 
             
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductOrigin = product.ProductOrigin
            };
            return View(editProductViewModel);
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditProduct(int id,EditProductViewModel editProductViewModel)
        {
            var productRepository = new ProductRepository();
            Product product = new Product
            {
                ProductName=editProductViewModel.ProductName,
                ProductOrigin =editProductViewModel.ProductOrigin,
                ProductPrice=editProductViewModel.ProductPrice
            };
            productRepository.UpdateProduct(id, product);
            return RedirectToAction("Index");
        }
    }

}