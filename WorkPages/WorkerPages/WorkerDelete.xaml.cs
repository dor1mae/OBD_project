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

namespace OBD.WorkPages.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkerDelete.xaml
    /// </summary>
    public partial class WorkerDelete : Page
    {
        public int id;
        private WorkerTest? t;
        OdbContext db = new OdbContext();
        Employee? temp;

        public WorkerDelete()
        {
            InitializeComponent();
            t = new WorkerTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idProf.Text != "")
            {
                id = t.idTest(idProf.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Employees.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Employees.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи работника зависят записи в других таблицах!");
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
