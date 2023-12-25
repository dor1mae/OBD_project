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
using System.Windows.Shapes;

namespace OBD.WorkPages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для deleteTicket.xaml
    /// </summary>
    public partial class deleteTicket : Window
    {
        OdbContext db = new OdbContext();

        public deleteTicket()
        {
            InitializeComponent();
        }

        private void deleteTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket temp = db.Tickets.Find(Convert.ToInt32(idEx.Text));
                if (temp != null)
                {
                    db.Tickets.Remove(temp);
                    db.SaveChanges();
                    MessageBox.Show("Удалено успешно!");
                }
                else
                {
                    MessageBox.Show("Удалять нечего!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в формате данных");
            }
        }
    }
}
