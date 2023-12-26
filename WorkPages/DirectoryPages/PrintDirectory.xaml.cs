using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace OBD.WorkPages.DirectoryPages
{
    /// <summary>
    /// Логика взаимодействия для PrintDirectory.xaml
    /// </summary>
    public partial class PrintDirectory : Window
    {
        private bool flag = false;
        OdbContext db = new OdbContext();
        List<SimpDir> items;

        public PrintDirectory()
        {
            InitializeComponent();
            Create_Table();
        }

        private void Create_Table()
        {
            var d = db.Directories.ToList();

            this.items = new List<SimpDir>(d.Count);


            foreach (Directory d2 in d)
            {
                items.Add(new SimpDir(
                    d2.Id,
                    d2.Title,
                    d2.Descrip,
                    d2.IdHall,
                    d2.Height,
                    d2.Width,
                    d2.Weigth,
                    d2.Length));
            }

            table.ItemsSource = items;

            table.ItemsSource = items;
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
                    printDialog.PrintVisual(canvas, "Отчет по экспонатам");

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
