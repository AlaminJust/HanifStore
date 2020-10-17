using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public class CategoryModelFactory : ICategoryModelFactory
    {
        public Category GetCategoryModel(CategoryModel model) 
        {
            var category = new Category
            {
                CategoryName = model.CategoryName,
                CreatedBy = model.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                DisplayOrder = model.DisplayOrder,
                IsPublish = model.IsPublish
            };
            return category;
        }
    }
}
