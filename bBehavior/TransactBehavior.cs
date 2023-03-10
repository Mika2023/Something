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
        public static List<Transaction> GetTransactionsSend(Card card)
        {
            using (AppDB appDB = new AppDB())
            {
                var transactions = appDB.Transactions.Where(t=>t.SenderId == card.Id);
                return transactions.ToList();
            }
        }
        public static List<Transaction> GetTransactionsGot(Card card)
        {
            using (AppDB appDB = new AppDB())
            {
                var transactions = appDB.Transactions.Where(t => t.RecieverId == card.Id);
                return transactions.ToList();
            }
        }
        public static void Post(Transaction transaction)
        {
            using (AppDB appDB = new AppDB())
            {
                var c = appDB.Transactions.FirstOrDefault(u => u.Code == transaction.Code);
                if (c != null)
                {
                    c.Sender = CardBehavior.GetId(c.SenderId);
                    c.Reciever = CardBehavior.GetId(c.RecieverId);
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
        //public static void PostSingle(Transaction transaction)
        //{
            
        //        var c = SingleTon.appDB.Transactions.FirstOrDefault(u => u.Code == transaction.Code);
        //        if (c != null)
        //        {
        //            c.UpdateEnty(transaction);
        //            SingleTon.appDB.Update(c);
        //        }
        //        else
        //        {
        //            SingleTon.appDB.Transactions.Add(transaction);
        //        }
        //        SingleTon.appDB.SaveChanges();
            
        //}
        public static void SendMoney(Card card, Transaction transaction)
        {
            
                transaction.SenderId = CardBehavior.GetId(SingleTon.card.Id).Id;
                transaction.RecieverId = CardBehavior.GetId(card.Id).Id;
            Post(transaction);
            transaction.Sender = CardBehavior.GetId(transaction.SenderId);
            transaction.Reciever = CardBehavior.GetId(transaction.RecieverId);
            transaction.Transact();
                CardBehavior.Post(transaction.Sender);
                CardBehavior.Post(transaction.Reciever);
            Post(transaction);

        }
        //public static List<Transaction> GetTransaction (Human human)
        //{
        //    var card = CardBehavior.GetId(human.CardId);
        //    if (card != null) return card.Transactions;
        //    else return new List<Transaction> ();
        //}
        //public static List<Transaction> GetTransaction(Card card)
        //{
        //    var c = CardBehavior.GetId(card.Id);
        //    if (c != null) return c.Transactions;
        //    else return new List<Transaction>();

        //}
    }
}
