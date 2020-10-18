using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface IProductService
    {
        public void insertProduct(Product product);
        public IList<Product> getProductByCategoryIdList(int categoryId = 0 , string productName = null);
        public Product getProductById(int productId);
        public void updateProduct(Product product , ProductModel model);
    }
}
