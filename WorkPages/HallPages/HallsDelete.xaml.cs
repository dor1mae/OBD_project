using OBD.WorkPages.HallPages;
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

namespace OBD.WorkPages.HallPages
{
    /// <summary>
    /// Логика взаимодействия для HallsDelete.xaml
    /// </summary>
    public partial class HallsDelete : Page
    {
        public int id;
        private HallTest? t;
        OdbContext db = new OdbContext();
        Hall? temp;

        public HallsDelete()
        {
            InitializeComponent();
            t = new HallTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idHall.Text != "")
            {
                id = t.idTest(idHall.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Halls.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Halls.Remove(temp);
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
