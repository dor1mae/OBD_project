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

namespace OBD.WorkPages.ExhibitionPages
{
    /// <summary>
    /// Логика взаимодействия для ExOptions.xaml
    /// </summary>
    public partial class ExOptions : Window
    {
        Frame frame;
        public ExOptions(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/ExhibitionPages/ExhibitionCreate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/ExhibitionPages/ExhibitionUpdate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/ExhibitionPages/ExhibitionDelete.xaml", UriKind.Relative));
            this.Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/ExhibitionPages/ExhibitionGet.xaml", UriKind.Relative));
            this.Close();
        }
    }
}
