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

namespace OBD.WorkPages.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkerGet.xaml
    /// </summary>
    public partial class WorkerGet : Page
    {
        OdbContext db = new OdbContext();


        public WorkerGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Employees.ToList();

            List<SimpWorker> items = new List<SimpWorker>(d.Count);

            foreach (Employee d2 in d)
            {
                items.Add(new SimpWorker(
                    d2.Id,
                    d2.FirstName,
                    d2.SecondName,
                    d2.FatherName,
                    d2.Salary,
                    d2.IdProf));
            }

            Table.ItemsSource = items;
        }

        private void printTickets_Click(object sender, RoutedEventArgs e)
        {
            PrintWorker p = new PrintWorker();
            p.Show();
        }
    }

    public class SimpWorker
    {
        public int Id { get; set; }

        public string SecondName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public int? IdProf { get; set; }

        public int Salary { get; set; }

        public SimpWorker(int id, string f, string s, string fat, int sal, int? i)
        {
            this.Id = id;
            this.FirstName = f;
            this.SecondName = s;
            this.FatherName = fat;
            this.Salary = sal;
            this.IdProf = i;

        }

    }
}
