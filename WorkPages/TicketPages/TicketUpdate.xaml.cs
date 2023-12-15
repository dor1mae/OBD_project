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
    /// Логика взаимодействия для TicketUpdate.xaml
    /// </summary>
    public partial class TicketUpdate : Page
    {
        public int id;
        private TicketTest t;
        OdbContext db = new OdbContext();
        Ticket? temp;

        public TicketUpdate()
        {
            InitializeComponent();
            t = new TicketTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idTicket.Text);

            if (t.f)
            {
                temp = db.Tickets.Find(id);

                if (temp != null)
                {
                    cost.Text = Convert.ToString(temp.Cost);

                    day.Text = t.DateTimeToString(temp.Day);

                    if (temp.IdExhibition != null)
                    {
                        idEx.Text = Convert.ToString(temp.IdExhibition);
                    }
                }
                else
                {
                    MessageBox.Show("Такого билета нет");
                }
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (idEx.Text == "")
            {
                Save_WithoutId();
            }
            else
            {
                Save_WithId();
            }
        }

        public void Save_WithId()
        {
            int c;
            int id_Ex;

            (c, id_Ex) = t.testVal(this.cost.Text, this.idEx.Text);
            DateTime d = t.StringToDateTime(this.day.Text);

            if (db.Exhibitions.Find(id_Ex) == null)
            {
                MessageBox.Show("Такой выставки нет");
                return;
            }

            if (t.f)
            {
                temp.Cost = Math.Abs(c);
                temp.Day = d;
                temp.IdExhibition = id_Ex;

                db.SaveChanges();

                MessageBox.Show("Успешно изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }

        public void Save_WithoutId()
        {
            try
            {
                int c = Convert.ToInt32(this.cost.Text);
                DateTime d = t.StringToDateTime(this.day.Text);

                if (t.f)
                {
                    try
                    {
                        temp.Cost = Math.Abs(c);
                        temp.Day = d;

                        db.SaveChanges();

                        MessageBox.Show("Успешно изменено!");
                    }
                    catch
                    {
                        MessageBox.Show("id должен быть указан.");
                    }
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
