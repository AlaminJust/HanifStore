using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface ICategoryService
    {
        public bool CheckDuplicateCategory(string categoryName);
        public IList<CategoryModel> GetAllCategories();
        public Category GetCategoryByNameOrId(string categoryName = null, int id = 0);
        public void InsertCategory(Category category);
    }
}
