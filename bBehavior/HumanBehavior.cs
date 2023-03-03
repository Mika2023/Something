using bBehavior.DataBase;
using bModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bBehavior
{
    public class HumanBehavior
    {
        public static void Post(Human human)
        {
            using (AppDB appDB = new AppDB())
            {
                var hum = appDB.People.FirstOrDefault(u => u.PasportNum == human.PasportNum);
                if (hum != null)
                {
                    hum.UpdateEnty(human);
                    appDB.Update(hum);
                }
                else
                {
                    //Human h = new Human()
                    //{
                    //    PasportNum = human.PasportNum,
                    //    Name = human.Name,
                    //    Lastname = human.Lastname,
                    //    Age = human.Age,
                    //    Card = SIngleTonReg.card,
                    //    User = SIngleTonReg.user
                    //};
                    appDB.People.Add(human);

                }
                appDB.SaveChanges();
            }
        }
        public static Human Get(int PasportNum)
        {
            using (AppDB appDB = new AppDB())
                return appDB.People.FirstOrDefault(u => u.PasportNum == PasportNum);
        }
        public static Human GetUser(int UserId)
        {
            using (AppDB appDB = new AppDB())
                return appDB.People.FirstOrDefault(u => u.UserId == UserId);
        }
    }
}
