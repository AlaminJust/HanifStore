using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface IOrderService
    {
        public void InsertShoppingCartItem(ShoppingCartItem shoppingCartItem);
    }
}
