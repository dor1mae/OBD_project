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

namespace OBD.WorkPages.DirectoryPages
{
    /// <summary>
    /// Логика взаимодействия для DirectoryOptions.xaml
    /// </summary>
    public partial class DirectoryOptions : Window
    {
        Frame frame;
        public DirectoryOptions(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("WorkPages/DirectoryPages/DirCreate.xaml", UriKind.Relative));
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void List_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
