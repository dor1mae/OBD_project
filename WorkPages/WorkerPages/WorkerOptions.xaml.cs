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

namespace OBD.WorkPages.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkerOptions.xaml
    /// </summary>
    public partial class WorkerOptions : Window
    {
        Frame frame;
        public WorkerOptions(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/WorkerPages/WorkerCreate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/WorkerPages/WorkerUpdate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/WorkerPages/WorkerDelete.xaml", UriKind.Relative));
            this.Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/WorkerPages/WorkerGet.xaml", UriKind.Relative));
            this.Close();
        }
    }
}
