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
    /// Логика взаимодействия для HallGet.xaml
    /// </summary>
    public partial class HallGet : Page
    {
        OdbContext db = new OdbContext();


        public HallGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Halls.ToList();

            List<SimpHall> items = new List<SimpHall>(d.Count);

            foreach (Hall d2 in d)
            {
                items.Add(new SimpHall(
                    d2.Id,
                    d2.Title,
                    d2.NumberExhibits,
                    d2.IdExhibit));
            }

            Table.ItemsSource = items;
        }
    }

    public class SimpHall
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int NumberExhibits { get; set; }

        public int? IdExhibit { get; set; }

        public SimpHall(int id, string t, int n, int? i)
        {
            this.Id = id;
            this.Title = t;
            this.NumberExhibits = n;
            this.IdExhibit = i;
        }

    }
}
