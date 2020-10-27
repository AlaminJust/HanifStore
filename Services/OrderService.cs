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
    }
}
