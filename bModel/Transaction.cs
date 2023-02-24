using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bModel
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public string Comment { get; set; }
        public Card Sender { get; set; }
        public Card Reciever { get; set; }
        public void Transact()
        {
            Date = DateTime.Now;
            Sender.Balance -= Sum;
            Reciever.Balance += Sum;
            Sender.Transactions.Add(this);
            Reciever.Transactions.Add(this);
        }
    }
}
