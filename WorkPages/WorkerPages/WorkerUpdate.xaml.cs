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
    /// Логика взаимодействия для WorkerUpdate.xaml
    /// </summary>
    public partial class WorkerUpdate : Page
    {
        public int id;
        private WorkerTest t;
        OdbContext db = new OdbContext();
        Employee? temp;

        public WorkerUpdate()
        {
            InitializeComponent();
            t = new WorkerTest();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            id = t.idTest(idW.Text);

            if (t.f)
            {
                temp = db.Employees.Find(id);

                if (temp != null)
                {
                    firstName.Text = temp.FirstName;
                    secondName.Text = temp.SecondName;
                    fatherName.Text = temp.FatherName;
                    salaryBox.Text = Convert.ToString(temp.Salary);

                    if (temp.IdProf != null)
                    {
                        idProf.Text = Convert.ToString(temp.IdProf);
                    }
                }
                else
                {
                    MessageBox.Show("Такого работника нет!");
                }
            }
            else
            {
                MessageBox.Show("Неверный id!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (idW.Text == "")
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
            int id_pr;

            id_pr = t.idTest(idProf.Text);
            int salary = t.idTest(salaryBox.Text);

            if (db.Professions.Find(id_pr) == null)
            {
                MessageBox.Show("Такой должности нет");
                return;
            }

            if (t.f)
            {
                temp.FirstName = firstName.Text;
                temp.SecondName = secondName.Text;
                temp.FatherName = fatherName.Text;
                temp.Salary = salary;
                temp.IdProf = id_pr;

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
                int salary = t.idTest(salaryBox.Text);

                if (t.f)
                {
                    temp.FirstName = firstName.Text;
                    temp.SecondName = secondName.Text;
                    temp.FatherName = fatherName.Text;
                    temp.Salary = salary;
                    temp.IdProf = null;

                    db.SaveChanges();

                    MessageBox.Show("Успешно изменено!");
                }
                else
                {
                    MessageBox.Show("Ошибка в зарплате");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в данных");
            }
        }
    }
}
