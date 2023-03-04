using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bModel
{
    public class Card
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CVC { get; set; }
        public int PinCode { get; set; }
        public int Balance { get; set; }
        public Human Owner { get; set; }
        public List<Transaction> TransactionsSener { get; set; } = new();
        public List<Transaction> TransactionsReciver { get; set; } = new();
        public void UpdateEnty(Card card)
        {
            if (card != null)
            {
                PinCode = card.PinCode;
                Balance = card.Balance;
                //foreach (Transaction t in card.Transactions) Transactions.Add(t);
                //Transactions = card.Transactions;
            }
        }
        public Card() { Balance = 100; }
    }
}
