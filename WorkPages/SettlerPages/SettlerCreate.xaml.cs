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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OBD.WorkPages.SettlerPages
{
    /// <summary>
    /// Логика взаимодействия для SettlerCreate.xaml
    /// </summary>
    public partial class SettlerCreate : Page
    {
        OdbContext db = new OdbContext();
        SettlerTest t = new SettlerTest();

        public SettlerCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DateTime newbirth = t.StringToDateTime(dateBirth.Text);

            if (t.f)
            {
                Settler temp = new Settler { FirstName = firstName.Text, SecondName = secondName.Text, FatherName = fatherName.Text, Email = email.Text, Birth = newbirth, Phone = phone.Text };

                db.Settlers.AddAsync(temp);
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
