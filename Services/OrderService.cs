using HanifStore.Client.Models;
using HanifStore.Data;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;

        public OrderService 
            ( 
                AppDbContext appDbContext, 
                IUserService userService 
            ) 
        {
            _appDbContext = appDbContext; 
            _userService = userService; 
        }

        public void DeleteShopingCartItemById(int id)
        {
            var shoppingCartItem = GetShoppingCartById(id);
            if(shoppingCartItem == null)
            {
                throw new NullReferenceException(nameof(shoppingCartItem));
            }
            _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            _userService.save();
        }

        public IList<ShoppingCartItem> getShoppingCartByCustomerId(string customerId = null, string userName = null)
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userId: customerId);
            if (user == null)
                user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName: userName);
            if(user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var shoppingItems = _appDbContext.ShoppingCartItems
                                .Where(x => x.CustomerId == user.Id).ToList();
            return shoppingItems;
        }

        public ShoppingCartItem GetShoppingCartById(int id)
        {
            if(id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }
            var shoppingCartItem = _appDbContext.ShoppingCartItems.Where(x => x.Id == id).FirstOrDefault();
            return shoppingCartItem;
        }

        public int getShoppingCartItemCountByCustomerId(string customerId = null, string userName = null)
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userId: customerId , userName:userName);
            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var shoppingItems = _appDbContext.ShoppingCartItems
                                .Where(x => x.CustomerId == user.Id).ToList();
            return shoppingItems.Count();
        }

        public void InsertShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if(shoppingCartItem == null)
            {
                throw new NullReferenceException(nameof(shoppingCartItem));
            }
            _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            _userService.save();
        }

        public void UpdateShoppingCartItem(ShoppingCartItemModel shoppingCartItemModel)
        {
            if(shoppingCartItemModel == null)
            {
                throw new NullReferenceException(nameof(shoppingCartItemModel));
            }
            var shoppingCart = GetShoppingCartById(shoppingCartItemModel.Id);
            if(shoppingCart == null)
            {
                throw new NullReferenceException(nameof(shoppingCart));
            }
            shoppingCart.Quantity = shoppingCartItemModel.Quantity;
            shoppingCart.isSelected = shoppingCartItemModel.isSelected;
            _appDbContext.ShoppingCartItems.Update(shoppingCart);
            _userService.save();
        }
    }
}
