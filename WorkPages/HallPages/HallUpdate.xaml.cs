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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OBD.WorkPages.HallPages
{
    /// <summary>
    /// Логика взаимодействия для HallUpdate.xaml
    /// </summary>
    public partial class HallUpdate : Page
    {
        public int id;
        private HallTest t;
        OdbContext db = new OdbContext();
        Hall? temp;

        public HallUpdate()
        {
            InitializeComponent();
            t = new HallTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idH.Text);

            if (t.f)
            {
                temp = db.Halls.Find(id);

                if(temp != null)
                {
                    title.Text = temp.Title;
                    number_ex.Text = Convert.ToString(temp.NumberExhibits);
                    if (temp.IdExhibit != null)
                    {
                        id_ex.Text = Convert.ToString(temp.IdExhibit);
                    }
                }
                else
                {
                    MessageBox.Show("Такого зала нет!");
                }
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (id_ex.Text == "")
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
            int numb_ex;
            int id_ex;

            (numb_ex, id_ex) = t.testVal(this.number_ex.Text, this.id_ex.Text);

            if(db.Exhibits.Find(id_ex) == null)
            {
                MessageBox.Show("Такой выставки нет.");
                return;
            }

            if (t.f)
            {
                temp.Title = title.Text;
                temp.NumberExhibits = numb_ex;
                temp.IdExhibit = id_ex;

                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }

        public void Save_WithoutId()
        {
            int numb_ex;

            try
            {
                numb_ex = Convert.ToInt32(number_ex.Text);

                temp.Title = title.Text;
                temp.NumberExhibits = numb_ex;

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
