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

namespace OBD.WorkPages.DirectoryPages
{
    /// <summary>
    /// Логика взаимодействия для DirUpdate.xaml
    /// </summary>
    public partial class DirUpdate : Page
    {
        public int id;
        private DirTest t;
        OdbContext db = new OdbContext();
        Directory? temp;

        public DirUpdate()
        {
            InitializeComponent();
            t = new DirTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idDir.Text);

            if(t.f)
            {
                temp = db.Directories.Find(id);

                title.Text = temp.Title;
                describ.Text = temp.Descrip;
                width.Text = Convert.ToString(temp.Width);
                length.Text = Convert.ToString(temp.Length);
                weigth.Text = Convert.ToString(temp.Weigth);
                height.Text = Convert.ToString(temp.Height);
                idHall1.Text = Convert.ToString(temp.IdHall);
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int height;
            int width;
            int id_hall;
            int weigth;
            int length;

            (height, width, id_hall, weigth, length) = t.testVal(this.height.Text, this.width.Text, this.idHall1.Text, this.weigth.Text, this.length.Text);

            if (t.f)
            {
                temp.Title = title.Text;
                temp.Descrip = describ.Text;
                temp.Length = length;
                temp.Width = width;
                temp.Height = height;
                temp.Weigth = weigth;
                temp.IdHall = id_hall;
                
                db.SaveChanges();

                MessageBox.Show("Успешно изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
