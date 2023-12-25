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
    /// Логика взаимодействия для SettlerGet.xaml
    /// </summary>
    public partial class SettlerGet : Page
    {
        OdbContext db = new OdbContext();


        public SettlerGet()
        {
            InitializeComponent();

            getItems();
        }

        public void getItems()
        {
            var d = db.Settlers.ToList();

            List<SimpSettler> items = new List<SimpSettler>(d.Count);

            foreach (Settler d2 in d)
            {
                items.Add(new SimpSettler(
                    d2.Id,
                    d2.FirstName,
                    d2.SecondName,
                    d2.FatherName,
                    d2.Email,
                    d2.Phone,
                    d2.Birth));
            }

            Table.ItemsSource = items;
        }
    }

    public class SimpSettler
    {
        public int Id { get; set; }

        public string SecondName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime Birth { get; set; }

        public string Email { get; set; } = null!;

        public int? IdTicket { get; set; }

        public SimpSettler(int id, string f, string s, string fat, string e, string p, DateTime b)
        {
            this.Id = id;
            this.FirstName = f;
            this.SecondName = s;
            this.FatherName = fat;
            this.Phone = p;
            this.Email = e;
            this.Birth = b;
            
        }

    }
}
