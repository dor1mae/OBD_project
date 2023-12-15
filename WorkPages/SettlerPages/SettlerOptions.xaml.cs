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

namespace OBD.WorkPages.SettlerPages
{
    /// <summary>
    /// Логика взаимодействия для SettlerOptions.xaml
    /// </summary>
    public partial class SettlerOptions : Window
    {
        Frame frame;
        public SettlerOptions(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/SettlerPages/SettlerCreate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/SettlerPages/SettlerUpdate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/SettlerPages/SettlerDelete.xaml", UriKind.Relative));
            this.Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/SettlerPages/SettlerGet.xaml", UriKind.Relative));
            this.Close();
        }
    }
}
