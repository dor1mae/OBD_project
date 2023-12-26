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

namespace OBD.WorkPages.TicketPages
{
    /// <summary>
    /// Логика взаимодействия для TicketGet.xaml
    /// </summary>
    public partial class TicketGet : Page
    {
        OdbContext db = new OdbContext();
        List<SimpTicket> items;

        public TicketGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Tickets.ToList();

            this.items = new List<SimpTicket>(d.Count);

            foreach (Ticket d2 in d)
            {
                items.Add(new SimpTicket(
                    d2.Id,
                    d2.Cost,
                    d2.Day,
                    d2.IdExhibition));
            }

            Table.ItemsSource = items;
        }

        private void printTickets_Click(object sender, RoutedEventArgs e)
        {
            printTickets t = new printTickets();
            t.Show();
        }
    }

    public class SimpTicket
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public DateTime Day { get; set; }

        public int? IdExhibition { get; set; }

        public SimpTicket(int id, int c, DateTime d, int? i)
        {
            this.Id = id;
            this.Cost = c;
            this.Day = d;
            this.IdExhibition = i;
        }

    }
}
