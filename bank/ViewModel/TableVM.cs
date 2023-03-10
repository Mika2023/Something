using bBehavior;
using bModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bank.ViewModel
{
    public class TableVM
    { 
        public List<Transaction> transactionsSend { get; set; } = new();
        public List<Transaction> transactionsGot { get; set; } = new();
        public TableVM()
        {
            var h = CardBehavior.GetId(SingleTon.card.Id);
            if (h != null)
            {
                transactionsSend = TransactBehavior.GetTransactionsSend(h);
                transactionsGot = TransactBehavior.GetTransactionsGot(h);
            }
            
        }
    }
}
