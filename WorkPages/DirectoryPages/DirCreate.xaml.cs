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
    /// Логика взаимодействия для DirCreate.xaml
    /// </summary>
    public partial class DirCreate : Page
    {
        OdbContext db = new OdbContext();
        DirTest t = new DirTest();

        public DirCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int height;
            int width;
            int id_hall;
            int weigth;
            int length;

            (height, width, id_hall, weigth, length) = t.testVal(this.height.Text, this.width.Text, this.idHall.Text, this.weigth.Text, this.length.Text);

            if(t.f)
            {
                Directory temp = new Directory {Title = this.title.Text, Descrip = this.describ.Text, Height = height, Width = width, Weigth = weigth, Length = length, IdHall=id_hall};

                db.Directories.AddAsync(temp);
                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
