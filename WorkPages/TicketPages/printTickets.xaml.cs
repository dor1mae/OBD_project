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

namespace OBD.WorkPages.TicketPages
{
    /// <summary>
    /// Логика взаимодействия для printTickets.xaml
    /// </summary>
    public partial class printTickets : Window
    {
        private bool flag = false;
        OdbContext db = new OdbContext();
        List<PrintTicket> items;

        public printTickets()
        {
            InitializeComponent();
            Create_Table();
        }

        private void Create_Table()
        {
            var d = db.Tickets.ToList();

            this.items = new List<PrintTicket>(d.Count);
            int AllMoney = 0;
            int AllTickets = 0;


            foreach (Ticket d2 in d)
            {
                items.Add(new PrintTicket(
                    d2.Id,
                    d2.Cost,
                    d2.Day,
                    d2.IdExhibition,
                    db.Exhibitions.Find(d2.IdExhibition).Title));

                AllTickets++;
                AllMoney += d2.Cost;
            }

            table.ItemsSource = items;

            table.ItemsSource = items;
            end.Content = $"Всего продано {AllTickets} билетов на сумму {AllMoney}";
            flag = true;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    // Скрыть Grid
                    grid.Visibility = Visibility.Hidden;

                    // Увеличить размер в 5 раз
                    canvas.LayoutTransform = new ScaleTransform(1.3, 2.2);

                    // Определить поля
                    int pageMargin = 5;

                    // Получить размер страницы
                    Size pageSize = new Size(printDialog.PrintableAreaWidth - pageMargin * 2,
                        printDialog.PrintableAreaHeight - 20);

                    // Инициировать установку размера элемента
                    canvas.Measure(pageSize);
                    canvas.Arrange(new Rect(pageMargin, pageMargin, pageSize.Width, pageSize.Height));

                    // Напечатать элемент
                    printDialog.PrintVisual(canvas, "Отчет по продажам билетов");

                    // Удалить трансформацию и снова сделать элемент видимым
                    canvas.LayoutTransform = null;
                    grid.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Нечего печатать");
                return;
            }
        }
    }

    public class PrintTicket
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public DateTime Day { get; set; }

        public int? IdExhibition { get; set; }

        public string ExTitle { get; set; }

        public PrintTicket(int id, int c, DateTime d, int? i, string ex)
        {
            this.Id = id;
            this.Cost = c;
            this.Day = d;
            this.IdExhibition = i;
            this.ExTitle = ex;
        }
    }
}
