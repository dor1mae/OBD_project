using OBD.WorkPages.SettlerPages;
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
    /// Логика взаимодействия для WatchProfile.xaml
    /// </summary>
    public partial class WatchProfile : Window
    {
        public int id;
        private SettlerTest t;
        OdbContext db = new OdbContext();
        Settler? temp;

        public WatchProfile(int id)
        {
            InitializeComponent();
            this.id = id;
            t = new SettlerTest();
            Search_Click();
        }

        private void Search_Click()
        {
            temp = db.Settlers.Find(id);

            if (temp != null)
            {
                firstName.Text = temp.FirstName;
                secondName.Text = temp.SecondName;
                fatherName.Text = temp.FatherName;
                dateBirth.Text = t.DateTimeToString(temp.Birth);
                email.Text = temp.Email;
                phone.Text = temp.Phone;
            }
            else
            {
                MessageBox.Show("Такого гостя нет!");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime birth = t.StringToDateTime(this.dateBirth.Text);

                if (t.f)
                {
                    temp.FirstName = firstName.Text;
                    temp.SecondName = secondName.Text;
                    temp.FatherName = fatherName.Text;
                    temp.Birth = birth;
                    temp.Phone = phone.Text;
                    temp.Email = email.Text;

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
