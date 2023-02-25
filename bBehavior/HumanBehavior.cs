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
                var hum = appDB.People.FirstOrDefault(u => u.Name==human.Name && u.Lastname==human.Lastname && u.Age==human.Age);
                if (hum != null)
                {
                    hum.UpdateEnty(human);
                    appDB.Update(hum);
                }
                else
                {
                    appDB.People.Add(human);

                }
                appDB.SaveChanges();
            }
        }
        public static Human Get(int Id)
        {
            using (AppDB appDB = new AppDB())
                return appDB.People.FirstOrDefault(u => u.Id == Id);
        }
    }
}
