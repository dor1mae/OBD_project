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

namespace OBD
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        OdbContext db = new OdbContext();

        public Reg()
        {
            InitializeComponent();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            var list = db.Users.ToList();

            foreach (User u in list)
            {
                if (u.Username == this.username.Text)
                {
                    MessageBox.Show("Такой пользователь уже есть");
                    return;
                }
            }

            int id = Create_Settler(username.Text);

            db.AddAsync(new User { Username = username.Text, Password = password.Text, IsAdmin = false, IdSettler = id });
            db.SaveChanges();

            MainWindowUser m = new MainWindowUser(id);
            m.Show();
            this.Close();
        }

        private int Create_Settler(string name)
        {
            db.AddAsync(new Settler { FirstName = username.Text, SecondName= username.Text, FatherName= username.Text, Birth=DateTime.Now, Email="", Phone="" });
            db.SaveChanges();

            var list = db.Settlers.ToList();

            foreach (Settler u in list)
            {
                if (u.FirstName == name)
                {
                    return u.Id;
                }
            }
            return 0;
        }
    }
}
