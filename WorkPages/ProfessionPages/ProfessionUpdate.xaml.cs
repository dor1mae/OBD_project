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
    /// Логика взаимодействия для ProfessionUpdate.xaml
    /// </summary>
    public partial class ProfessionUpdate : Page
    {
        public int id;
        OdbContext db = new OdbContext();
        Profession? temp;
        ProfTest t = new ProfTest();

        public ProfessionUpdate()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idP.Text);

            if (t.f)
            {
                temp = db.Professions.Find(id);

                title.Text = temp.Title;
                worktime.Text = temp.Worktime;
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                temp.Title = title.Text;
                temp.Worktime = worktime.Text;

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
