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
    public class SendVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        Window _sendwindow;
        public SendVM(Window mainWindow) => _sendwindow = mainWindow;
        string _comment;
        int _sum;
        int _cardnum;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public int Sum
        {
            get => _sum;
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public int CardNum
        {
            get => _cardnum;
            set
            {
                _cardnum = value;
                OnPropertyChanged("CardNum");
            }
        }
        Command? send;
        public Command Send
        {
            get
            {
                return send ??
                  (send = new Command((o) =>
                  {
                      var _card = CardBehavior.Get(CardNum);
                      if (_card != null)
                      {

                      }
                      else
                      {
                          MessageBox.Show("Неверный номер карты");
                      }
                  }));
            }
        }
    }
    
}
