using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_Smoke
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();
            string[] fileNames = Directory.GetFiles("game images");
            int rowCount = (int)Math.Floor(fileNames.Length / 2.0);
            List<RowDefinition> row = new List<RowDefinition>();
            for (int i = 0; i < rowCount; i++)
            {
                row.Add(new RowDefinition());
                row[i * 2].Height = new GridLength(30);
                row.Add(new RowDefinition());
                row[i * 2 + 1].Height = new GridLength(130);
                row.Add(new RowDefinition());
            }
            for(int i = 0; i<row.Count; i++)
            {
                GameGrid.RowDefinitions.Add(row[i]);
            }
            List<Button> buttons = new List<Button>();
            int rowNum = 2;
            for (int i = 0; i < fileNames.Length; i++)
            {
                int columnNum = i % 2 == 0 ? 1 : 3;
                buttons.Add(new Button());
                buttons[i].SetValue(Grid.RowProperty, rowNum);
                buttons[i].SetValue(Grid.ColumnProperty, columnNum);
                GameGrid.Children.Add(buttons[i]);
                if (i % 2 == 0 && i != 0)
                {
                    rowNum += 2;
                }
            }
            List<Image> images = new List<Image>();
            rowNum = 1;
            for (int i = 0; i <  fileNames.Length; i++)
            {
                int columnNum = i% 2 == 0 ? 1 : 3;
                images.Add(new Image());
                images[i].Source = new BitmapImage(new Uri(fileNames[i], UriKind.Relative));
                images[i].SetValue(Grid.RowProperty, rowNum);
                images[i].SetValue(Grid.ColumnProperty, columnNum);
                GameGrid.Children.Add(images[i]);
                if (i%2==0 && i!=0)
                {
                    rowNum += 2;
                }
            }
        }
    }
}
