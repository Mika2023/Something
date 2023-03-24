using bBehavior;
using bModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace bank.ViewModel
{
    public class IncardVM : INotifyPropertyChanged
    {
        Window _window { get; set; }
        public int _ID;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Human human { get; set; }
        public IncardVM(Window window)
        {
            _window = window;
        }
        public IncardVM(Window window, int Id)
        {
            _ID = Id;
            human = HumanBehavior.GetByCard(ID);
            _window = window;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public int ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        Command? _In;
        public Command In
        {
            get
            {
                return _In ??
                  (_In = new Command((o) =>
                  {
                      InCard inCard = new InCard(ID);
                      inCard.Show();
                  }));
            }
        }
    }
}
