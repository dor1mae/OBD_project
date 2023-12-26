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
    /// Логика взаимодействия для TicketCreate.xaml
    /// </summary>
    public partial class TicketCreate : Page
    {
        OdbContext db = new OdbContext();
        TicketTest t = new TicketTest();

        public TicketCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (this.idEx.Text == "")
            {
                Create_WithoutId();
            }
            else
            {
                Create_WithId();
            }
        }

        public void Create_WithId()
        {
            int c;
            int id_Ex;

            (c, id_Ex) = t.testVal(this.cost.Text, this.idEx.Text);
            DateTime day = t.StringToDateTime(this.day.Text);

            if (db.Exhibitions.Find(id_Ex) == null)
            {
                MessageBox.Show("Такой выставки нет");
            }

            if (t.f)
            {
                Ticket temp = new Ticket { Cost = Math.Abs(c), Day = day, IdExhibition = id_Ex };

                db.Tickets.AddAsync(temp);
                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }

        public void Create_WithoutId()
        {
            try
            {
                int c = Convert.ToInt32(this.cost.Text);
                DateTime d = t.StringToDateTime(this.day.Text);

                if (t.f)
                {
                    Ticket temp = new Ticket { Cost = Math.Abs(c), Day = d };

                    db.Tickets.AddAsync(temp);
                    db.SaveChanges();

                    MessageBox.Show("Успешно сохранено!");
                }
                else
                {
                    MessageBox.Show("Ошибка в дате");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
