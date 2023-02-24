namespace bModel
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }      
        public string Password { get; set; }
        public Human Human { get; set; }
        public void UpdateEnty(User user)
        {
            if (user != null)
            {
                Password = user.Password;
            }
        }
        public static bool operator true(User user)
        {
            if (user.Login == "")
                throw new Exception("Не верный логин");
            if (user.Password == "")
                throw new Exception("Пустой пароль");
            if (user.Password.Length <= 6)
                throw new Exception("Слишком короткий пароль");

            return true;
        }
        public static bool operator false(User user)
        {
            return !(user.Login != "" && user.Password != "" && user.Password.Length > 6);
        }
    }
}