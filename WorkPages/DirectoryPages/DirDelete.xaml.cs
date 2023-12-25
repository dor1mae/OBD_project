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

namespace OBD.WorkPages.DirectoryPages
{
    /// <summary>
    /// Логика взаимодействия для DirDelete.xaml
    /// </summary>
    public partial class DirDelete : Page
    {
        public int id;
        private DirTest? t;
        OdbContext db = new OdbContext();
        Directory? temp;

        public DirDelete()
        {
            InitializeComponent();
            t = new DirTest();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(idDir.Text != "")
            {
                id = t.idTest(idDir.Text);
            }
            else
            {
                MessageBox.Show("Поле пустое");
                return;
            }

            if (t.f)
            {
                
                temp = db.Directories.Find(id);
                if (temp != null)
                {
                    db.Directories.Remove(temp);
                    db.SaveChanges();
                    MessageBox.Show("Удалено успешно!");
                }   
                else
                {
                    MessageBox.Show("Удалять нечего!");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат данных");
            }    
        }
    }
}
