using bBehavior;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bank.ViewModel
{
    public class AuthVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        Window _mainWindow;
        public AuthVM(Window mainWindow) => _mainWindow = mainWindow;
        string _login;
        string _password;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        Command? _Auth;
        public Command Auth
        {
            get
            {
                return _Auth ??
                  (_Auth = new Command((o) =>
                  {
                      var _user = UserBehavior.GetAuth(Login, Password);
                      if (_user != null)
                      {
                          SingleTon.user = _user;
                          InfoHuman info = new InfoHuman();
                          info.Show();
                          _mainWindow.Close();

                      }
                      else
                      {
                          MessageBox.Show("Неверный логин или пароль");
                      }
                  }));
            }
        }
    }
}
