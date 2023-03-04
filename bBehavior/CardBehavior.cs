using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bBehavior.DataBase;
using bModel;

namespace bBehavior
{
    public static class CardBehavior
    {
        public static Card Get(int CardNum)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Cards.FirstOrDefault(c=>c.CardNumber == CardNum);
        }
        public static void Post(Card card)
        {
            using (AppDB appDB = new AppDB())
            {
                var c = appDB.Cards.FirstOrDefault(u => u.CardNumber == card.CardNumber);
                if (c != null)
                {
                    c.UpdateEnty(card);
                    
                    appDB.Update(c);
                }
                else
                {
                    appDB.Cards.Add(card);
                }
                appDB.SaveChanges();
            }
        }
        public static Card GetAuth(int PinCode, int CardNum)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Cards.FirstOrDefault(u => u.PinCode == PinCode && u.CardNumber == CardNum);
        }
        public static Card GetId(int cardId)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Cards.FirstOrDefault(c => c.Id == cardId);
        }
        public static void PostSingle(Card card)
        {
            var c = SingleTon.appDB.Cards.FirstOrDefault(u => u.CardNumber == card.CardNumber);
            if (c != null)
            {
                c.UpdateEnty(card);
                SingleTon.appDB.Update(c);
            }
            else
            {
                SingleTon.appDB.Cards.Add(card);
            }
            SingleTon.appDB.SaveChanges();
        }
    }
}
