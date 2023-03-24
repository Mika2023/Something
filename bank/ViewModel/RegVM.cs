using bBehavior;
using bModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bank.ViewModel
{
    public class RegVM
    {
        Window _window;
        public User User { get; set; }
        public RegVM(Window window)
        {
            User = new User();
            _window = window;
        }
        Command? _Reg;
        public Command Reg
        {
            get
            {
                return _Reg ??
                  (_Reg = new Command((o) =>
                  {
                      try
                      {
                          if (User)
                          {
                              var user = UserBehavior.Get(User.Login);
                              if (user != null) { MessageBox.Show("Пользователь уже существует!"); return; }
                              SIngleTonReg.user = User;
                              InfoCard infoHuman = new InfoCard();
                              infoHuman.Show();
                              _window.Close();
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
    }
}
