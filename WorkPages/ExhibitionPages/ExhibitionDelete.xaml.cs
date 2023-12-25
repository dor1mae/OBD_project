using OBD.WorkPages.ExhibitionPages;
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

namespace OBD.WorkPages.ExhibitionPages
{
    /// <summary>
    /// Логика взаимодействия для ExhibitionDelete.xaml
    /// </summary>
    public partial class ExhibitionDelete : Page
    {
        public int id;
        private ExhibitionTest? t;
        OdbContext db = new OdbContext();
        Exhibition? temp;

        public ExhibitionDelete()
        {
            InitializeComponent();
            t = new ExhibitionTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idEx.Text != "")
            {
                id = t.idTest(idEx.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Exhibitions.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Exhibitions.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи выставки зависят записи в других таблицах!");
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
