﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ClientCoppelData.xaml
    /// </summary>
    public partial class ClientCoppelData : Page
    {
        public ClientCoppelData()
        {
            InitializeComponent();
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new FindClientCoppel());
        }

        private void btnFindClient_Click(object sender, RoutedEventArgs e)
        {
            //pantalla para buscar el teléfono
        }
    }
}