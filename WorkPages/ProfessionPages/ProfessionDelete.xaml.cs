using OBD.WorkPages.ProfessionPages;
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

namespace OBD.WorkPages.ProfessionPages
{
    /// <summary>
    /// Логика взаимодействия для ProfessionDelete.xaml
    /// </summary>
    public partial class ProfessionDelete : Page
    {
        public int id;
        private ProfTest? t;
        OdbContext db = new OdbContext();
        Profession? temp;

        public ProfessionDelete()
        {
            InitializeComponent();
            t = new ProfTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idP.Text != "")
            {
                id = t.idTest(idP.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Professions.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Professions.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи должности зависят записи в других таблицах!");
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
