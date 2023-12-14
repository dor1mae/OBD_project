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
    /// Логика взаимодействия для ExhibitionGet.xaml
    /// </summary>
    public partial class ExhibitionGet : Page
    {
        OdbContext db = new OdbContext();


        public ExhibitionGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Exhibitions.ToList();

            List<SimpExhibition> items = new List<SimpExhibition>(d.Count);

            foreach (Exhibition d2 in d)
            {
                items.Add(new SimpExhibition(
                    d2.Id,
                    d2.Title,
                    d2.TimeOfStart,
                    d2.TimeOfEnd,
                    d2.NumberTickets,
                    d2.IdOrg));
            }

            Table.ItemsSource = items;
        }
    }

    public class SimpExhibition
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime TimeOfStart { get; set; }

        public DateTime TimeOfEnd { get; set; }

        public int NumberTickets { get; set; }

        public int? IdOrg { get; set; }

        public SimpExhibition(int id, string t, DateTime s, DateTime f, int n, int? i)
        {
            this.Id = id;
            this.Title = t;
            this.TimeOfStart = s;
            this.TimeOfEnd = f;
            this.NumberTickets = n;
            this.IdOrg = i;
        }

    }
}
