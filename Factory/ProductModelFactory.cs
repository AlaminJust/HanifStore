using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public class ProductModelFactory : IProductModelFactory
    {
        public ProductModel getProductModelFromProduct(Product product)
        {
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            var productModel = new ProductModel
            {
                CategoryId = product.CategoryId,
                DisplayOrder = product.DisplayOrder,
                Id = product.Id,
                IsDeleted = product.IsDeleted,
                IsPublish = product.IsPublish,
                Price = product.Price,
                ProductName = product.ProductName,
                ProductPicture = product.ProductPicture,
                ProductSpecificationIds = product.ProductSpecificationIds,
                Quantity = product.Quantity
            };
            return productModel;
        }

        public IList<ProductModel> getProductModelList(IList<Product> products)
        {
            var productsModel = products.Select(x => new ProductModel
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                DisplayOrder = x.DisplayOrder,
                IsDeleted = x.IsDeleted,
                IsPublish = x.IsPublish,
                Price = x.Price,
                ProductName = x.ProductName,
                ProductPicture = x.ProductPicture,
                ProductSpecificationIds = x.ProductSpecificationIds,
                Quantity = x.Quantity
            }).ToList();
            return productsModel;
        }

        public Product productModelFactory(ProductModel model)
        {
            if(model == null)
            {
                throw new NullReferenceException(nameof(model));
            }
            var product = new Product
            {
                DisplayOrder = model.DisplayOrder,
                CategoryId = model.CategoryId,
                IsDeleted = false,
                IsPublish = model.IsPublish,
                Price = model.Price,
                ProductName = model.ProductName,
                ProductPicture = model.ProductPicture,
                ProductSpecificationIds = model.ProductSpecificationIds,
                Quantity = model.Quantity
            };
            return product;
        }
    }
}
