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
            if (human!=null && card!=null)
            {
                human.Card = card;
                human.User = user;
            }
        }
    }
}
