using bBehavior.DataBase;
using bModel;
using Microsoft.EntityFrameworkCore;
namespace bBehavior
{
    public static class UserBehavior
    {
        public static User Get(int Id)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u => u.Id == Id);
        }
        public static User Get(string login)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u => u.Login == login);
        }
        public static User GetAuth(string login, string password)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public static void Post(User user)
        {
            using (AppDB appDB = new AppDB())
            {
                var us = appDB.Users.FirstOrDefault(u => u.Login == user.Login);
                if (us != null)
                {
                    us.UpdateEnty(user);
                    appDB.Update(us);
                }
                else
                {
                    appDB.Users.Add(user);
                }
                appDB.SaveChanges();
            }
        }
    }
}