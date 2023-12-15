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
    /// Логика взаимодействия для ProfessionGet.xaml
    /// </summary>
    public partial class ProfessionGet : Page
    {
        OdbContext db = new OdbContext();


        public ProfessionGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Professions.ToList();

            List<SimpProfession> items = new List<SimpProfession>(d.Count);

            foreach (Profession d2 in d)
            {
                items.Add(new SimpProfession(
                    d2.Id,
                    d2.Title,
                    d2.Worktime));
            }

            Table.ItemsSource = items;
        }
    }

    public class SimpProfession
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string WorkTime { get; set; } = null!;

        public SimpProfession(int id, string t, string w)
        {
            this.Id = id;
            this.Title = t;
            this.WorkTime = w;
        }

    }
}
