﻿using bank.ViewModel;
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
    /// Логика взаимодействия для Send.xaml
    /// </summary>
    public partial class Send : Window
    {
        
        public Send()
        {
            InitializeComponent();
            DataContext = new SendVM(this);
        }

        
    }
}
