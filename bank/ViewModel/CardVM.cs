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
    public class CardVM
    {
        Window _window;
        public Card card { get; set; }
        public CardVM(Window window)
        {
            card = new Card();
            _window = window;
        }
        Command? _cardinfo;
        public Command CardInfo
        {
            get
            {
                return _cardinfo ??
                  (_cardinfo = new Command((o) =>
                  {
                      try
                      {
                          var car = CardBehavior.Get(card.CardNumber);
                          if (car != null) { MessageBox.Show("Неверный номер карты"); return; }
                          CardBehavior.Post(card);
                          //SingleTon.card = card;
                          //SingleTon.join();
                          //SIngleTonReg.card = card;
                          InfoHuman info = new InfoHuman();
                          info.Show();
                          _window.Close();
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
