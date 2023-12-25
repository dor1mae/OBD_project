using OBD.WorkPages.DirectoryPages;
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
    /// Логика взаимодействия для HallCreate.xaml
    /// </summary>
    public partial class HallCreate : Page
    {
        OdbContext db = new OdbContext();
        HallTest t = new HallTest();

        public HallCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(id_ex.Text == "")
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
            int numb_ex;
            int id_ex;

            (numb_ex, id_ex) = t.testVal(this.number_ex.Text, this.id_ex.Text);

            if (t.f)
            {
                Hall temp = new Hall { Title = this.title.Text, NumberExhibits = numb_ex, IdExhibit = id_ex };

                db.Halls.AddAsync(temp);
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
                int numb = Convert.ToInt32(number_ex.Text);
                Hall temp = new Hall { Title = this.title.Text, NumberExhibits = numb};

                db.Halls.AddAsync(temp);
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
