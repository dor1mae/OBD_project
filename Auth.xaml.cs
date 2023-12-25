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
using OBD.DatabaseClasses;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using System.Data.Odbc;
using OBD.WorkPages.WorkerPages;

namespace OBD
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        OdbContext db = new OdbContext();
        
        public Auth()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
            this.Close();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            var list = db.Users.ToList();

            foreach (User u in list)
            {
                if (u.Username == this.username.Text)
                {
                    //MessageBox.Show($"{temp.Username}, {temp.Password}\n{username.Text}, {password.Text}");
                    if (u.Password == this.password.Text)
                    {
                        if(u.IsAdmin == true)
                        {
                            MainWindow m = new MainWindow();
                            m.Show();
                            this.Close();
                        }
                        else
                        {
                            MainWindowUser m = new MainWindowUser(u.IdSettler);
                            m.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль или имя пользователя");
                        break;
                    }
                }
            }
        }
    }
}
