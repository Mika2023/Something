using bank.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bank
{
    /// <summary>
    /// Логика взаимодействия для Sign_in.xaml
    /// </summary>
    public partial class Sign_in : Window
    {
        public Sign_in()
        {
            InitializeComponent();
            DataContext = new AuthVM(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sign_up registr = new Sign_up();
            registr.ShowDialog();
        }
    }
}
