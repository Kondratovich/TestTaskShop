using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestTaskShop.ViewModels;

namespace TestTaskShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult StoreProducts(int id)
        {
            StoreProductsViewModel viewModel = new StoreProductsViewModel() {
                StoreId = id,
                StoreName = _unitOfWork.Stores.GetById(id)?.Name,
                Products = _unitOfWork.Stores.GetStoreProducts(id)
            };

            if (viewModel.StoreName == null) {
                return NotFound();
            }

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int storeId, int productId)
        {
            Product product = _unitOfWork.Products.GetById(productId);
            if (product == null) {
                return NotFound();
            }
            ProductFormViewModel viewModel = new ProductFormViewModel() {
                StoreId = storeId,
                ActionName = "Edit",
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description
            };

            return View("ProductForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid) {
                return View("ProductForm", viewModel);
            }

            _unitOfWork.Products.Update(new Product() {
                Id = viewModel.ProductId,
                Name = viewModel.ProductName,
                Description = viewModel.ProductDescription
            });
            _unitOfWork.Complete();

            return RedirectToAction("StoreProducts", "Products", new { id = viewModel.StoreId });
        }
        [HttpGet]
        public IActionResult Add(int storeId)
        {
            ProductFormViewModel viewModel = new ProductFormViewModel() {
                StoreId = storeId,
                ActionName = "Add"
            };

            return View("ProductForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid) {
                return View("ProductForm", viewModel);
            }

            _unitOfWork.Stores.AddProductToStore(viewModel.StoreId, new Product() {
                Id = viewModel.ProductId,
                Name = viewModel.ProductName,
                Description = viewModel.ProductDescription
            });
            _unitOfWork.Complete();

            return RedirectToAction("StoreProducts", "Products", new { id = viewModel.StoreId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int storeId, int productId)
        {
            Product remProduct = _unitOfWork.Products.GetById(productId);
            if(remProduct == null) {
                return NotFound();
            }
            _unitOfWork.Stores.RemoveProductFromStore(storeId, remProduct);
            _unitOfWork.Complete();

            return RedirectToAction("StoreProducts", "Products", new { id = storeId });
        }
    }
}
