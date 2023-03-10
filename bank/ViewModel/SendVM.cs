using bBehavior;
using bBehavior.DataBase;
using bModel;
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
    public class SendVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        Window _sendwindow;
        public Transaction transaction { get; set; }
        int randCode;
        public SendVM(Window sendWindow)
        {
            transaction = new Transaction();
            _sendwindow = sendWindow;
        }
        int _cardnum;
        public int CardNum
        {
            get => _cardnum;
            set
            {
                _cardnum = value;
                OnPropertyChanged("CardNum");
            }
        }
        public int RandCode
        {
            get => randCode;
            set
            {
                randCode = value;
                OnPropertyChanged("RandCode");
            }
        }
        //string _comment;
        //int _sum;
        //int _cardnum;
        //public string Comment
        //{
        //    get => _comment;
        //    set
        //    {
        //        _comment = value;
        //        OnPropertyChanged("Comment");
        //    }
        //}
        //public int Sum
        //{
        //    get => _sum;
        //    set
        //    {
        //        _sum = value;
        //        OnPropertyChanged("Sum");
        //    }
        //}

        Command? send;
        public Command Send
        {
            get
            {
                return send ??
                  (send = new Command((o) =>
                  {
                      var _card = CardBehavior.Get(CardNum);
                      if (_card != null && randCode==transaction.Code)
                      {
                          
                              TransactBehavior.SendMoney(_card, transaction);
                          
                          Main main = new Main();
                          main.Show();
                          _sendwindow.Close();
                      }
                      else
                      {
                          MessageBox.Show("Неверный номер карты или код");
                      }
                  }));
            }
        }
        Command? rand;
        public Command Rand
        {
            get
            {
                return rand ??
                  (rand = new Command((o) =>
                  {
                     Random random = new Random();
                     RandCode = random.Next();
                  }));
            }
        }
    }
    
}
