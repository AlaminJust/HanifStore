using HanifStore.Data;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
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
