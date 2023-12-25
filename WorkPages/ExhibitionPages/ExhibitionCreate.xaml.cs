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
    /// Логика взаимодействия для ExhibitionCreate.xaml
    /// </summary>
    public partial class ExhibitionCreate : Page
    {
        OdbContext db = new OdbContext();
        ExhibitionTest t = new ExhibitionTest();

        public ExhibitionCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (this.idOrg.Text == "")
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
            int nTickets;
            int id_Org;

            (nTickets, id_Org) = t.testVal(this.numberTickets.Text, this.idOrg.Text);
            DateTime start = t.StringToDateTime(this.dateStart.Text);
            DateTime finish = t.StringToDateTime(this.dateFinish.Text);

            if(db.Organizators.Find(id_Org) == null)
            {
                MessageBox.Show("Такого организатора нет");
                return;
            }

            if (t.f)
            {
                Exhibition temp = new Exhibition { Title = this.title.Text, TimeOfStart = start, TimeOfEnd = finish, NumberTickets = nTickets, IdOrg = id_Org};

                db.Exhibitions.AddAsync(temp);
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
                int nTickets = Convert.ToInt32(this.numberTickets.Text);
                DateTime start = t.StringToDateTime(this.dateStart.Text);
                DateTime finish = t.StringToDateTime(this.dateFinish.Text);

                if (t.f)
                {
                    Exhibition temp = new Exhibition { Title = this.title.Text, TimeOfStart = start, TimeOfEnd = finish, NumberTickets = nTickets };

                    db.Exhibitions.AddAsync(temp);
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
