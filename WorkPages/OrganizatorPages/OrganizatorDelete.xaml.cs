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
    /// Логика взаимодействия для OrganizatorDelete.xaml
    /// </summary>
    public partial class OrganizatorDelete : Page
    {
        public int id;
        private OrganizatorTest? t;
        OdbContext db = new OdbContext();
        Organizator? temp;

        public OrganizatorDelete()
        {
            InitializeComponent();
            t = new OrganizatorTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idOrg.Text != "")
            {
                id = t.idTest(idOrg.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Organizators.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Organizators.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи зала зависят записи в других таблицах!");
                    }
                }
                else
                {
                    MessageBox.Show("Удалять нечего!");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат данных");
            }
        }
    }
}
