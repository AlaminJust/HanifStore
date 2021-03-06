﻿using HanifStore.Client.Models;
using HanifStore.Domain;
using HanifStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public class OrderModelFactory : IOrderModelFactory
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public OrderModelFactory
            (
                IProductService productService,
                IUserService userService
            )
        {
            _productService = productService;
            _userService = userService;
        }
        public ShoppingCartItem GetShoppingCartItem(ShoppingCartItemModel model , string vendorId)
        {
            var product = _productService.getProductById(model.ProductId);
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName: vendorId);
            if(user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var ShoppingCart = new ShoppingCartItem
            {
                AttributeXml = model.AttributeXml,
                CreatedOn = DateTime.UtcNow,
                CustomerId = user.Id,
                Subtotal = model.Subtotal,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UpdatedOn = DateTime.UtcNow,
                VendorId = user.Id,
                isSelected = model.isSelected
            };
            return ShoppingCart;
        }

        public IList<ShoppingCartItemModel> getShoppingCartItemsModel(IList<ShoppingCartItem> shoppingCartItems)
        {
            var shoppingCartItemsModel = shoppingCartItems.Select(x => new ShoppingCartItemModel
            {
                AttributeXml = x.AttributeXml,
                CreatedOn = x.CreatedOn,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                UpdatedOn = x.UpdatedOn,
                VendorId = x.VendorId,
                Id = x.Id,
                isSelected = x.isSelected
            }).ToList();
            return shoppingCartItemsModel;
        }
    }
}
