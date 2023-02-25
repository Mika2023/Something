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
    public class InfoVM
    {

        Window _window;
        public Human Human { get; set; }
        public InfoVM(Window window)
        {
            Human = new Human();
            _window = window;
        }
        Command? _interesting;
        public Command Interesting
        {
            get
            {
                return _interesting ??
                  (_interesting = new Command((o) =>
                  {
                      try
                      {
                          HumanBehavior.Post(Human);
                          SingleTon.human = Human;
                          InfoCard infoCard = new InfoCard();
                          infoCard.Show();
                          _window.Close();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        Command? _skip;
        public Command Skip
        {
            get
            {
                return _skip ??
                    (_skip= new Command((o) =>
                    {
                        
                        var human = HumanBehavior.Get(SingleTon.user.Human.Id);
                        if (human != null)
                        {
                            var card = CardBehavior.Get(SingleTon.user.Human.Card.CardNumber);
                            if(card != null)
                            {
                                SingleTon.card = card;
                                SingleTon.human = human;
                                SingleTon.join();
                                Main main = new Main();
                                main.Show();
                                _window?.Close();
                            }
                            
                        }
                        else { MessageBox.Show("Сначала введите данные!"); return; }
                    }));
                    
                    
                    
            }
        }
    }
}
