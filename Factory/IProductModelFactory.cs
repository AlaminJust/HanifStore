using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public interface IProductModelFactory
    {
        public Product productModelFactory(ProductModel model);
        public IList<ProductModel> getProductModelList(IList<Product> products);
        public ProductModel getProductModelFromProduct(Product product);
    }
}
