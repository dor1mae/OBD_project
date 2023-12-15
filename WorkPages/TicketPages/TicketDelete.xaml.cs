using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBD.WorkPages.TicketPages;
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
    /// Логика взаимодействия для TicketDelete.xaml
    /// </summary>
    public partial class TicketDelete : Page
    {
        public int id;
        private TicketTest? t;
        OdbContext db = new OdbContext();
        Ticket? temp;

        public TicketDelete()
        {
            InitializeComponent();
            t = new TicketTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idTicket.Text != "")
            {
                id = t.idTest(idTicket.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {

                temp = db.Tickets.Find(id);
                if (temp != null)
                {
                    try
                    {
                        db.Tickets.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!");
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить\n От данной записи билета зависят записи в других таблицах!");
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
