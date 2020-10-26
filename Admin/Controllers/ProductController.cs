using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using HanifStore.Admin.Models;
using HanifStore.Factory;
using HanifStore.Infrustracture.Cache;
using HanifStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ProductController
            (
                ICategoryService categoryService,
                ICategoryModelFactory categoryModelFactory,
                IProductModelFactory productModelFactory,
                IProductService productService,
                IFileService fileService,
                ICacheService cacheService,
                IUserService userService,
                IRoleService roleService
            )
        {
            _categoryService = categoryService;
            _categoryModelFactory = categoryModelFactory;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _fileService = fileService;
            _cacheService = cacheService;
            _userService = userService;
            _roleService = roleService;
        }
        [Route("category")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAllCategories();
            return View("~/Admin/Views/Product/CategoryList.cshtml",categories);
        }
        [Route("create")]
        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model , IFormFile productFile) 
        {
            if (ModelState.IsValid)
            {
                var user = _userService.getIdentityUserByUserNameOrPhoneNumber(User.Identity.Name);
                var uniqueFilePath = _fileService.InsertFile(productFile , "img");
                if(uniqueFilePath != null)
                {
                    model.ProductPicture = uniqueFilePath;
                    var product = _productModelFactory.productModelFactory(model,user.Id);
                    _productService.insertProduct(product);
                    _cacheService.ClearCacheKey();
                }
            }
            return RedirectToAction("list");
        }
        [Route("list")]
        [Authorize(Roles = "Admin,Vendor")]
        public async Task<IActionResult> productList(int categoryId = 0 , string productName = null)
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName: User.Identity.Name);
            var vendor = await _roleService.IsUserInSpecificRole(user.Id, "Vendor");
            var admin = await _roleService.IsUserInSpecificRole(user.Id, "Admin");
            var vendorId = (vendor == true && !admin) ? user.Id : null; 
            var products = _productService.getProductByCategoryIdList(categoryId, productName, vendorId:vendorId);
            var productsModel = _productModelFactory.getProductModelList(products);
            var productListModel = new ProductsListModel();
            productListModel.ProductsModel = productsModel;
            return View("~/Admin/Views/Product/Product.cshtml",productListModel);
        }
        [Route("edit")]
        [Authorize(Roles = "Admin,Vendor")]
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
        [Authorize(Roles = "Admin,Vendor")]
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
                _cacheService.ClearCacheKey();
            }
            return RedirectToAction("list");
        }
    }
}