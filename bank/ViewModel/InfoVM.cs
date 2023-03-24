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
                     
                          HumanBehavior.Post(Human);
                      CardBehavior.Post(SIngleTonReg.card);
                      UserBehavior.Post(SIngleTonReg.user);
                          
                          _window.Close();
                  }));
            }
        }
    }
}
