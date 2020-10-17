using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public interface ICategoryModelFactory
    {
        public Category GetCategoryModel(CategoryModel model);
    }
}
