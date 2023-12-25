using OBD.WorkPages.WorkerPages;
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
    /// Логика взаимодействия для WorkerCreate.xaml
    /// </summary>
    public partial class WorkerCreate : Page
    {
        OdbContext db = new OdbContext();
        WorkerTest t = new WorkerTest();

        public WorkerCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (idProf.Text == "")
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
            int id_pr = t.idTest(this.idProf.Text);

            if (db.Professions.Find(id_pr) == null)
            {
                MessageBox.Show("Такой должности нет");
                return;
            }

            int salary = t.idTest(salaryBox.Text);

            if (t.f)
            {
                Employee temp = new Employee { FirstName = firstName.Text, SecondName = secondName.Text, FatherName = fatherName.Text, Salary = salary, IdProf = id_pr };

                db.Employees.AddAsync(temp);
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
            int salary = t.idTest(salaryBox.Text);

            if (t.f)
            {
                Employee temp = new Employee { FirstName = firstName.Text, SecondName = secondName.Text, FatherName = fatherName.Text, Salary = salary };

                db.Employees.AddAsync(temp);
                db.SaveChanges();

                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
