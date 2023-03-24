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
    public class MainVM
    {
        Window _window;
        public Card card { get; set; }
        public Human human { get; set; }
        public MainVM(Window window)
        {
            card = CardBehavior.GetId(SingleTon.card.Id);
            human = HumanBehavior.Get(SingleTon.human.PasportNum);
            _window = window;
        }
    }
}
