using HanifStore.Admin.Models;
using HanifStore.Data;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;

        public TransactionService
            (
                AppDbContext appDbContext,
                IUserService userService
            )
        {
            _appDbContext = appDbContext;
            _userService = userService;
        }
        public void InsertCustomerBuy(CustomersBuy customersBuy)
        {
            if(customersBuy == null)
            {
                throw new NullReferenceException(nameof(customersBuy));
            }
            _appDbContext.CustomersBuys.Add(customersBuy);
            _userService.save();
        }

        public IList<TransactionListModel> getTransactionListByUserId(string userId)
        {
            if(userId == null)
            {
                throw new NullReferenceException(nameof(userId));
            }
            var transactions = _appDbContext.CustomersBuys.Where(x => x.UserId == userId)
                                .Select(x => new TransactionListModel 
                                        { 
                                            AddedBy = x.AddedBy,
                                            CreatedOn = x.CreatedOn,
                                            Description = x.Description,
                                            Price = x.Price,
                                            Deposite = x.Deposite,
                                            UserId = x.UserId
                                        }).ToList();
            return transactions;
        }
    }
}
