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
using OBD.DatabaseClasses;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using System.Data.Odbc;
using OBD.WorkPages.DirectoryPages;

namespace OBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OdbContext dbContext = new OdbContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Directory test = new Directory { Title = "Сая", Descrip = "Описание для фигурки Саи", Height = 10, Length = 5, Weigth = 1, Width = 5};
            dbContext.Directories.Add(test);
            dbContext.SaveChanges();
        }

        private void Directory_Click(object sender, RoutedEventArgs e)
        {
            DirectoryOptions directory = new DirectoryOptions(mainFrame);
            directory.Owner = this;

            directory.Show();
        }
    }
}
