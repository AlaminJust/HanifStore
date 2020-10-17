using HanifStore.Admin.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface ITransactionService
    {
        public void InsertCustomerBuy(CustomersBuy customersBuy);
        public IList<TransactionListModel> getTransactionListByUserId(string userId);
    }
}
