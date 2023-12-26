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
    /// Логика взаимодействия для DirGet.xaml
    /// </summary>
    public partial class DirGet : Page
    {
        OdbContext db = new OdbContext();


        public DirGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Directories.ToList();

            List<SimpDir> items = new List<SimpDir>(d.Count);

            foreach(Directory d2 in d)
            {
                items.Add(new SimpDir(
                    d2.Id,
                    d2.Title,
                    d2.Descrip,
                    d2.IdHall,
                    d2.Height,
                    d2.Width,
                    d2.Weigth,
                    d2.Length));
            }

            Table.ItemsSource = items;
        }

        private void printDirectory_Click(object sender, RoutedEventArgs e)
        {
            PrintDirectory p = new PrintDirectory();
            p.Show();
        }
    }

    public class SimpDir
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Descrip { get; set; } = null!;

        public int? IdHall { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public int Weigth { get; set; }

        public SimpDir(int id, string t, string d, int? idHall, int h, int width, int weigth, int l)
        {
            this.Id = id;
            this.Title = t;
            this.Descrip = d;
            this.IdHall = idHall;
            this.Width = width;
            this.Weigth = weigth;
            this.Length = l;
            this.Height = h;
        }

    }
}
