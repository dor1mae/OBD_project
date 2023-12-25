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

namespace OBD.WorkPages.OrganizatorPages
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorGet.xaml
    /// </summary>
    public partial class OrganizatorGet : Page
    {
        OdbContext db = new OdbContext();


        public OrganizatorGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Organizators.ToList();

            List<SimpOrganizator> items = new List<SimpOrganizator>(d.Count);

            foreach (Organizator d2 in d)
            {
                items.Add(new SimpOrganizator(
                    d2.Id,
                    d2.Name,
                    d2.Phone,
                    d2.Adress,
                    d2.IdDirectory,
                    d2.Email));
            }

            Table.ItemsSource = items;
        }
    }

    public class SimpOrganizator
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int? IdDirectory { get; set; }

        public string Email { get; set; } = null!;

        public SimpOrganizator(int id, string n, string p, string a, int? i, string e)
        {
            this.Id = id;
            this.Name = n;
            this.Phone = p;
            this.Adress = a;
            this.IdDirectory = i;
            this.Email = e;
        }

    }
}
