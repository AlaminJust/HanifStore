using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using HanifStore.Admin.Models;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryModelFactory _categoryModelFactory;

        public ProductController
            (
                ICategoryService categoryService,
                ICategoryModelFactory categoryModelFactory
            )
        {
            _categoryService = categoryService;
            _categoryModelFactory = categoryModelFactory;
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

    }
}