﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bModel
{
    public enum TypeCard
    {
        Sender,
        Reciever
    }
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public string Comment { get; set; }
        public int Code { get; set; }
        //public TypeCard type { get; set; }
        //public List<Card> Cards { get; set; }
        public Card Sender { get; set; }
        public int SenderId { get; set; }
        public Card Reciever { get; set; }
        public int RecieverId { get; set; }
        public void Transact()
        {
            Date = DateTime.Now;
            //switch(type)
            //{
            //    case TypeCard.Sender:
            //        var Card = 
            //}
            Sender.Balance -= Sum;
            Reciever.Balance += Sum;
            Sender.TransactionsSener.Add(this);
            Reciever.TransactionsReciver.Add(this);
        }
        public void UpdateEnty(Transaction transaction)
        {
            if (transaction != null)
            {
                Comment = transaction.Comment;
                Date = transaction.Date;
            }
            
        }
    }
}
