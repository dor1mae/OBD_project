using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBD.WorkPages.SettlerPages;
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

namespace OBD.WorkPages.SettlerPages
{
    /// <summary>
    /// Логика взаимодействия для SettlerDelete.xaml
    /// </summary>
    public partial class SettlerDelete : Page
    {
        public int id;
        private SettlerTest? t;
        OdbContext db = new OdbContext();
        Settler? temp;

        public SettlerDelete()
        {
            InitializeComponent();
            t = new SettlerTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idSet.Text != "")
            {
                id = t.idTest(idSet.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Settlers.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Settlers.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи посетителя зависят записи в других таблицах!");
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
