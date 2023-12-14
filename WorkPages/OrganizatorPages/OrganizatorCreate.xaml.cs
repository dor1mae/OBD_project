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
    /// Логика взаимодействия для OrganizatorCreate.xaml
    /// </summary>
    public partial class OrganizatorCreate : Page
    {
        OdbContext db = new OdbContext();
        OrganizatorTest t = new OrganizatorTest();

        public OrganizatorCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (idDir.Text == "")
            {
                Create_WithoutId();
            }
            else
            {
                Create_WithId();
            }
        }

        public void Create_WithId()
        {
            int id_dir = t.idTest(this.idDir.Text);

            if (db.Directories.Find(id_dir) == null)
            {
                MessageBox.Show("Такого словаря нет");
                return;
            }

            if (t.f)
            {
                Organizator temp = new Organizator { Name = this.title.Text, Adress = this.adress.Text, Email = this.email.Text, Phone = this.phone.Text, IdDirectory = id_dir};

                db.Organizators.AddAsync(temp);
                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }

        public void Create_WithoutId()
        {
            try
            {
                Organizator temp = new Organizator { Name = this.title.Text, Adress = this.adress.Text, Email = this.email.Text, Phone = this.phone.Text };

                db.Organizators.AddAsync(temp);
                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            catch
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
