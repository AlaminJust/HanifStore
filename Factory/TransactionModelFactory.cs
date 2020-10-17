using HanifStore.Admin.Models;
using HanifStore.Domain;
using HanifStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public class TransactionModelFactory : ITransactionModelFactory
    {
        private readonly IUserService _userService;

        public TransactionModelFactory
            (
                IUserService userService
            )
        {
            _userService = userService;
        }
        public CustomersBuy CustomerBuyModelFactory(CustomerBuyModel model , string addedBy)
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName: model.Username);
            if(user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var customerBuy = new CustomersBuy
            {
                CreatedOn = DateTime.UtcNow,
                AddedBy = addedBy,
                Price = model.Price,
                Deposite = model.Deposite,
                Description = model.Description,
                UserId = user.Id
            };
            return customerBuy;
        }
    }
}
