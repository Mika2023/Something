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
                      //SingleTon.human = Human;
                          
                          _window.Close();
                      
                      //catch (Exception ex)
                      //{
                      //    MessageBox.Show(ex.Message);
                      //}
                  }));
            }
        }
        //Command? _skip;
        //public Command Skip
        //{
        //    get
        //    {
        //        return _skip ??
        //            (_skip= new Command((o) =>
        //            {

        //                try
        //                {
        //                    //var human = HumanBehavior.GetUser(SingleTon.user.Id);
        //                    //if (human != null)
        //                    //{
        //                    //    var card = CardBehavior.GetId(human.CardId);
        //                    //    if (card != null)
        //                    //    {
        //                    //        SingleTon.human = human;
        //                    //        SingleTon.card = card;
        //                    //        SingleTon.join();
        //                    //        Main main = new Main();
        //                    //        main.Show();
        //                    //        _window?.Close();
        //                    //    }
        //                    //}

        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                }

        //            }));
                    
                    
                    
        //    }
        //}
    }
}
