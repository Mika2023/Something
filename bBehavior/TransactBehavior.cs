using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static void Post(Transaction transaction)
        {
            using (AppDB appDB = new AppDB())
            {
                var c = appDB.Transactions.FirstOrDefault(u => u.Code == transaction.Code);
                if (c != null)
                {
                    c.UpdateEnty(transaction);
                    appDB.Update(c);
                }
                else
                {
                    appDB.Transactions.Add(transaction);
                }
                appDB.SaveChanges();
            }
        }
        public static void PostSingle(Transaction transaction)
        {
            
                var c = SingleTon.appDB.Transactions.FirstOrDefault(u => u.Code == transaction.Code);
                if (c != null)
                {
                    c.UpdateEnty(transaction);
                    SingleTon.appDB.Update(c);
                }
                else
                {
                    SingleTon.appDB.Transactions.Add(transaction);
                }
                SingleTon.appDB.SaveChanges();
            
        }
        public static void SendMoney(Card card, Transaction transaction)
        {
            
                transaction.Sender = CardBehavior.GetId(SingleTon.card.Id);
                transaction.Reciever = CardBehavior.GetId(card.Id);
                transaction.Transact();
                CardBehavior.Post(transaction.Sender);
                CardBehavior.Post(transaction.Reciever);
            //PostSingle(transaction);
        }
        public static List<Transaction> GetTransaction (Human human)
        {
            var card = CardBehavior.GetId(human.CardId);
            if (card != null) return card.Transactions;
            else return new List<Transaction> ();
        }
        public static List<Transaction> GetTransaction(Card card)
        {
            var c = CardBehavior.GetId(card.Id);
            if (c != null) return c.Transactions;
            else return new List<Transaction>();
        }
    }
}
