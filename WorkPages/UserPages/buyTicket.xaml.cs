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
    /// Логика взаимодействия для buyTicket.xaml
    /// </summary>
    public partial class buyTicket : Window
    {
        OdbContext db = new OdbContext();
        int id_settler;

        public buyTicket(int id)
        {
            this.id_settler = id;
            InitializeComponent();
        }

        private void butTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idEx.Text);

                Ticket temp = new Ticket { Cost = 2000, Day = db.Exhibitions.Find(id).TimeOfStart, IdExhibition = id, IdSettler = id_settler };
                db.Tickets.Add(temp);
                db.SaveChanges();

                MessageBox.Show("Билет куплен!");
            }
            catch 
            {
                MessageBox.Show("Ошибка в формате данных");
            }
        }
    }
}
