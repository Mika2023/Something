using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bBehavior.DataBase;
using bModel;
using Microsoft.EntityFrameworkCore.Internal;

namespace bBehavior
{
    public static class TransactBehavior
    {
        public static Transaction[] GetTransactions(Human human)
        {
            using (AppDB appDB = new AppDB())
            {
                var transactions = appDB.Transactions.Where(t=>t.Sender.Id == human.CardId || t.Reciever.Id==human.CardId);
                return transactions.ToArray();
            }
        }
        public static void SendMoney(Card card, int sum, string comment)
        {
            Transaction transaction = new Transaction();
            transaction.Reciever = card;
            transaction.Sum = sum;
            transaction.Comment = comment;
            transaction.Sender = SingleTon.human.Card;
            transaction.Transact();
        }
    }
}
