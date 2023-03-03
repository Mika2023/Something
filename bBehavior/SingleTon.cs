using bModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bBehavior
{
    public static class SingleTon
    {
        public static Human human { get; set; }
        public static User user { get; set; }
        public static Card card { get; set; }
        public static void join()
        {
            var Hum = HumanBehavior.GetUser(user.Id);
            if (Hum!=null)
            {
                var C = CardBehavior.GetId(Hum.CardId);
                if (C!=null)
                {
                    human = Hum;
                    card = C;
                }
                else
                {
                    throw new Exception("Введите данные карты!");

                }
            }
            else throw new Exception("Введите свои данные!");
        }
    }
}
