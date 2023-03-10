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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        Page got;
        Page send;
        Page Got
        {
            get
            {
                return got ?? (got = new GotPage());
            }
        }
        Page Send
        {
            get
            {
                return send ?? (send = new SendPage());
            }
        }
        public Table()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.NavigationService.Navigate(Got);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameMain.NavigationService.Navigate(Send);
        }
    }
}
