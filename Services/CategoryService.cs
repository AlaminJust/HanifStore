using HanifStore.Admin.Models;
using HanifStore.Data;
using HanifStore.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;

        public CategoryService
            (
                AppDbContext appDbContext,
                IUserService userService
            )
        {
            _appDbContext = appDbContext;
            _userService = userService;
        }
        public bool CheckDuplicateCategory(string categoryName)
        {
            if(categoryName == null)
            {
                throw new NullReferenceException(nameof(categoryName));
            }
            return _appDbContext.Categories.Where(x => x.CategoryName == categoryName.ToLower().Trim()).Any();
        }

        public IList<CategoryModel> GetAllCategories()
        {
            var categories = _appDbContext.Categories.Select(x => new CategoryModel
            {
                CategoryName = x.CategoryName,
                CreatedBy = x.CreatedBy,
                IsPublish = x.IsPublish,
                CreatedOn = x.CreatedOn,
                DisplayOrder = x.DisplayOrder
            }).OrderBy(x => x.DisplayOrder).ToList();
            return categories;
        }

        public IList<SelectListItem> getAllCategorisAsSelectListItem()
        {
            var categories = _appDbContext.Categories.Where(x => x.IsPublish).Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();
            return categories;
        }

        public Category GetCategoryByNameOrId(string categoryName = null, int id = 0) 
        {
            if(categoryName == null && id == 0)
            {
                throw new NullReferenceException(nameof(categoryName));
            }
            var category = _appDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;
        }

        public void InsertCategory(Category category)
        {
            if(category == null)
            {
                throw new NullReferenceException(nameof(category));
            }
            _appDbContext.Categories.Add(category);
            _userService.save();
        }
    }
}
