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
using OBD.DatabaseClasses;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using System.Data.Odbc;
using OBD.WorkPages.DirectoryPages;
using OBD.WorkPages.HallPages;
using OBD.WorkPages.ExhibitionPages;
using OBD.WorkPages.OrganizatorPages;
using OBD.WorkPages.TicketPages;
using OBD.WorkPages.ProfessionPages;
using OBD.WorkPages.SettlerPages;
using OBD.WorkPages.WorkerPages;
using OBD.WorkPages.UserPages;

namespace OBD
{
    /// <summary>
    /// Interaction logic for MainWindowUser.xaml
    /// </summary>
    public partial class MainWindowUser : Window
    {
        OdbContext db = new OdbContext();
        int? id_settler;
        
        public MainWindowUser(int? id)
        {
            this.id_settler = id;
            InitializeComponent();
        }

        private void Hall_Click(object sender, RoutedEventArgs e)
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

            table.ItemsSource = items;
        }

        private void Exhibition_Click(object sender, RoutedEventArgs e)
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

            table.ItemsSource = items;
        }

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            var d = db.Tickets.ToList();

            List<SimpTicket> items = new List<SimpTicket>(d.Count);

            foreach (Ticket d2 in d)
            {

                if (d2.IdSettler == id_settler)
                {
                    items.Add(new SimpTicket(
                        d2.Id,
                        d2.Cost,
                        d2.Day,
                        d2.IdExhibition));
                }
            }

            table.ItemsSource = items;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            WatchProfile wp = new WatchProfile((int)id_settler);
            wp.Owner = this;
            wp.Show();
        }

        private void buyTicket_Click(object sender, RoutedEventArgs e)
        {
            buyTicket b = new buyTicket((int)id_settler);
            b.Owner = this;
            b.Show();
        }

        private void deleteTicket_Click(object sender, RoutedEventArgs e)
        {
            deleteTicket b = new deleteTicket();
            b.Owner = this;
            b.Show();
        }

        private void printTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
