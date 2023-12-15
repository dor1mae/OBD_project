using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBD.WorkPages.OrganizatorPages;
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

namespace OBD.WorkPages.OrganizatorPages
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorUpdate.xaml
    /// </summary>
    public partial class OrganizatorUpdate : Page
    {
        public int id;
        private OrganizatorTest t;
        OdbContext db = new OdbContext();
        Organizator? temp;

        public OrganizatorUpdate()
        {
            InitializeComponent();
            t = new OrganizatorTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idOrg.Text);

            if (t.f)
            {
                temp = db.Organizators.Find(id);

                if (temp != null)
                {
                    title.Text = temp.Name;
                    email.Text = temp.Email;
                    adress.Text = temp.Adress;
                    phone.Text = temp.Phone;

                    if (temp.IdDirectory != null)
                    {
                        idDir.Text = Convert.ToString(temp.IdDirectory);
                    }
                }
                else
                {
                    MessageBox.Show("Такого организатора нет!");
                }
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (idOrg.Text == "")
            {
                Save_WithoutId();
            }
            else
            {
                Save_WithId();
            }
        }

        public void Save_WithId()
        {
            int id_Dir = t.idTest(idDir.Text);

            if (db.Directories.Find(id_Dir) == null)
            {
                MessageBox.Show("Такого словаря нет");
                return;
            }

            if (t.f)
            {
                try
                {
                    temp.Name = title.Text;
                    temp.Email = email.Text;
                    temp.Adress = adress.Text;
                    temp.Phone = phone.Text;
                    temp.IdDirectory = id_Dir;

                    db.SaveChanges();

                    MessageBox.Show("Успешно изменено!");
                }
                catch
                {
                    MessageBox.Show("Ошибка в данных");
                }
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }

        public void Save_WithoutId()
        {
            try
            {
                temp.Name = title.Text;
                temp.Email = email.Text;
                temp.Adress = adress.Text;
                temp.Phone = phone.Text;
                temp.IdDirectory = null;

                db.SaveChanges();

                MessageBox.Show("Успешно изменено!");
            }
            catch
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
