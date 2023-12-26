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
    /// Логика взаимодействия для printTicket.xaml
    /// </summary>
    public partial class printTicket : Window
    {
        private bool flag = false;
        OdbContext db = new OdbContext();

        public printTicket()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idTicket.Text);

                Ticket ticket = db.Tickets.Find(id);
                if(ticket != null)
                {
                    this.idTick.Content = id;
                    this.nameExh.Content = db.Exhibitions.Find(ticket.IdExhibition).Title;
                    this.fioSettler.Content = $"{db.Settlers.Find(ticket.IdSettler).SecondName} {db.Settlers.Find(ticket.IdSettler).FirstName} {db.Settlers.Find(ticket.IdSettler).FatherName}";
                    this.costTicket.Content = ticket.Cost;
                    this.dayExh.Content = ticket.Day;

                    this.flag = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Такого билета нет");
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка в формате данных");
                return;
            } 
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if(flag == true)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    // Скрыть Grid
                    grid.Visibility = Visibility.Hidden;

                    // Увеличить размер в 5 раз
                    canvas.LayoutTransform = new ScaleTransform(5, 5);

                    // Определить поля
                    int pageMargin = 5;

                    // Получить размер страницы
                    Size pageSize = new Size(printDialog.PrintableAreaWidth - pageMargin * 2,
                        printDialog.PrintableAreaHeight - 20);

                    // Инициировать установку размера элемента
                    canvas.Measure(pageSize);
                    canvas.Arrange(new Rect(pageMargin, pageMargin, pageSize.Width, pageSize.Height));

                    // Напечатать элемент
                    printDialog.PrintVisual(canvas, "Распечатываем элемент Canvas");

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
}
