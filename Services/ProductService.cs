using HanifStore.Admin.Models;
using HanifStore.Data;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanifStore.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;

        public ProductService
            (
                AppDbContext appDbContext,
                IUserService userService
            )
        {
            _appDbContext = appDbContext;
            _userService = userService;
        }

        public IList<Product> getProductByCategoryIdList(int categoryId = 0 , string productName = null, bool publish = true)
        {
            var query = _appDbContext.Products.Where(x => !x.IsDeleted);
            if (!publish) query = query.Where(x => x.IsPublish);
            if(categoryId > 0)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            } 
            if(productName != null)
            {
                query = query.Where(x => x.ProductName.Contains(productName, StringComparison.InvariantCultureIgnoreCase));
            }
            return query.OrderBy(x => x.DisplayOrder).ToList();
        }

        public Product getProductById(int productId)
        {
            if(productId == 0)
            {
                throw new NullReferenceException(nameof(productId));
            }
            return _appDbContext.Products.Where(x => x.Id == productId).FirstOrDefault();
        }

        public void insertProduct(Product product)
        {
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            _appDbContext.Products.Add(product);
            _userService.save();
        }

        public void updateProduct(Product product , ProductModel model)
        {
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            product.CategoryId = model.CategoryId;
            product.ProductName = model.ProductName;
            product.Quantity = model.Quantity;
            product.Price = model.Price;
            product.DisplayOrder = model.DisplayOrder;
            product.ProductPicture = model.ProductPicture == null ? product.ProductPicture : model.ProductPicture;
            product.IsPublish = model.IsPublish;
            _appDbContext.Products.Update(product);
            _userService.save();
        }
    }
}
