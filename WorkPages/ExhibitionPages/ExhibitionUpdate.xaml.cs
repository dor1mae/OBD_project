using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBD.WorkPages.ExhibitionPages;
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
    /// Логика взаимодействия для ExhibitionUpdate.xaml
    /// </summary>
    public partial class ExhibitionUpdate : Page
    {
        public int id;
        private ExhibitionTest t;
        OdbContext db = new OdbContext();
        Exhibition? temp;

        public ExhibitionUpdate()
        {
            InitializeComponent();
            t = new ExhibitionTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idEx.Text);

            if (t.f)
            {
                temp = db.Exhibitions.Find(id);

                if (temp != null)
                {
                    title.Text = temp.Title;
                    dateStart.Text = t.DateTimeToString(temp.TimeOfStart);
                    dateFinish.Text = t.DateTimeToString(temp.TimeOfEnd);
                    numberTickets.Text = Convert.ToString(temp.NumberTickets);

                    if (temp.IdOrg != null)
                    {
                        idOrg.Text = Convert.ToString(temp.IdOrg);
                    }
                }
                else
                {
                    MessageBox.Show("Такого зала нет!");
                }
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (idOrg.Text == "")
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
            int nTickets;
            int id_Org;

            (nTickets, id_Org) = t.testVal(this.numberTickets.Text, this.idOrg.Text);
            DateTime start = t.StringToDateTime(this.dateStart.Text);
            DateTime finish = t.StringToDateTime(this.dateFinish.Text);

            if (db.Organizators.Find(id_Org) == null)
            {
                MessageBox.Show("Такого организатора нет");
                return;
            }

            if (t.f)
            {
                temp.Title = title.Text;
                temp.TimeOfStart = start;
                temp.TimeOfEnd = finish;
                temp.NumberTickets = nTickets;
                temp.IdOrg = id_Org;

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
                int nTickets = Convert.ToInt32(this.numberTickets.Text);
                DateTime start = t.StringToDateTime(this.dateStart.Text);
                DateTime finish = t.StringToDateTime(this.dateFinish.Text);

                if (t.f)
                {
                    temp.Title = title.Text;
                    temp.TimeOfStart = start;
                    temp.TimeOfEnd = finish;
                    temp.NumberTickets = nTickets;

                    db.SaveChanges();

                    MessageBox.Show("Успешно изменено!");
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
