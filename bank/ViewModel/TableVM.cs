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
        Window _window;
        public List<Transaction> transactions { get; set; } = new();
        public TableVM(Window window)
        {
            var h = CardBehavior.GetId(SingleTon.card.Id);
            if (h != null) transactions = TransactBehavior.GetTransaction(h);
            _window = window;
            
        }
    }
}
