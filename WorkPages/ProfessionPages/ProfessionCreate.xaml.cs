using OBD.WorkPages.DirectoryPages;
using OBD.WorkPages.ProfessionPages;
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

namespace OBD.WorkPages.ProfessionPages
{
    /// <summary>
    /// Логика взаимодействия для ProfessionCreate.xaml
    /// </summary>
    public partial class ProfessionCreate : Page
    {
        OdbContext db = new OdbContext();

        public ProfessionCreate()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Profession t = new Profession { Title = title.Text, Worktime = worktime.Text };

                db.Professions.AddAsync(t);
                db.SaveChanges();

                MessageBox.Show("Создано!");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
