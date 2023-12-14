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
using System.Windows.Shapes;

namespace OBD.WorkPages.HallPages
{
    /// <summary>
    /// Логика взаимодействия для HallOptions.xaml
    /// </summary>
    public partial class HallOptions : Window
    {
        Frame frame;
        public HallOptions(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/HallPages/HallCreate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/HallPages/HallUpdate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/HallPages/HallsDelete.xaml", UriKind.Relative));
            this.Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/HallPages/HallGet.xaml", UriKind.Relative));
            this.Close();
        }
    }
}
