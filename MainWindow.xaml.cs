﻿using Pippi_SocketAsyncLib;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Pippi_AsyncTimeServer
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeSocketServer mServer;
        public MainWindow()
        {
            InitializeComponent();
            mServer = new TimeSocketServer();
            btn_disconetti.IsEnabled = false;
        }
        

        private void Btn_Ascolto_Click(object sender, RoutedEventArgs e)
        {
            Btn_Ascolto.IsEnabled = false;
            mServer.InAscolto();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
            btn_disconetti.IsEnabled = true;

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            mServer.inviaATutti();
        }

        private void btn_disconetti_Click(object sender, RoutedEventArgs e)
        {
            mServer.disconetti();
            Btn_Ascolto.IsEnabled = true;
            btn_disconetti.IsEnabled = false;
        }
    }
}
