using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using HanifStore.Admin.Models;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryModelFactory _categoryModelFactory;
        private readonly IProductModelFactory _productModelFactory; 
        private readonly IProductService _productService;
        private readonly IFileService _fileService;

        public ProductController
            (
                ICategoryService categoryService,
                ICategoryModelFactory categoryModelFactory,
                IProductModelFactory productModelFactory,
                IProductService productService,
                IFileService fileService
            )
        {
            _categoryService = categoryService;
            _categoryModelFactory = categoryModelFactory;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _fileService = fileService;
        }
        [Route("category")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            model.CreatedBy = User.Identity.Name;
            var category = _categoryModelFactory.GetCategoryModel(model);
            if (category == null)
            {
                throw new NullReferenceException(nameof(category));
            }
            if (!_categoryService.CheckDuplicateCategory(model.CategoryName))
            {
                _categoryService.InsertCategory(category);
                return Json(new { result = "Category name added.", url = Url.Action("categorylist", "product") });
            }
            else
            {
                return BadRequest(Json(new { error = "Category name is already exist." }));
            }
        }
        [Route("categorylist")]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAllCategories();
            return View("~/Admin/Views/Product/CategoryList.cshtml",categories);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model , IFormFile productFile) 
        {
            if (ModelState.IsValid)
            {
                var uniqueFilePath = _fileService.InsertFile(productFile , "img");
                if(uniqueFilePath != null)
                {
                    model.ProductPicture = uniqueFilePath;
                    var product = _productModelFactory.productModelFactory(model);
                    _productService.insertProduct(product);
                }
            }
            return RedirectToAction("list");
        }
        [Route("list")]
        public IActionResult productList(int categoryId = 0 , string productName = null)
        {
            var products = _productService.getProductByCategoryIdList(categoryId, productName);
            var productsModel = _productModelFactory.getProductModelList(products);
            var productListModel = new ProductsListModel();
            productListModel.ProductsModel = productsModel;
            return View("~/Admin/Views/Product/Product.cshtml",productListModel);
        }
        [Route("edit")]
        public IActionResult ProductEdit(int productId = 0)
        {
            var product = _productService.getProductById(productId);
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            var productModel = _productModelFactory.getProductModelFromProduct(product);
            return View("~/Admin/Views/Product/_editProduct.cshtml", productModel);
        }
        [Route("edit")]
        [HttpPost]
        public IActionResult ProductEdit(ProductModel model , IFormFile productFile)
        {
            if (ModelState.IsValid)
            {
                string uniqepath = null;
                if (productFile != null)
                    uniqepath = _fileService.InsertFile(productFile, "img");
                var product = _productService.getProductById(model.Id);
                model.ProductPicture = uniqepath;
                _productService.updateProduct(product, model);
            }
            return RedirectToAction("list");
        }
    }
}