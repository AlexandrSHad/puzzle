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

namespace puzzle_test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _mainViewModel;
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            img5.Source = new BitmapImage(new Uri("/img/6.png", UriKind.Relative));
            img6.Source = new BitmapImage(new Uri("/img/5.png", UriKind.Relative));
            //MessageBox.Show(img5.Source.BaseUri);
        }

        private void gridBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //MessageBox.Show("Drug");
                Image img = (Image)e.Source;
                
                if (img.Source is BitmapImage)
                {
                    MessageBox.Show("BitmapImage");
                    return;
                }

                //if (img.Source is BitmapFrame)
                //{
                //    MessageBox.Show("BitmapFrame");
                //}

                BitmapFrame bmp = (BitmapFrame)img.Source;
                string uriString = bmp.Decoder.ToString();

                DataObject drugData = new DataObject(uriString);

                DragDrop.DoDragDrop(img, drugData, DragDropEffects.Move);
            }
        }

        private void gridBoard_Drop(object sender, DragEventArgs e)
        {
            Image img = (Image)e.Source;

            string uriString = (string)e.Data.GetData(typeof(string));

            img.Source = new BitmapImage(new Uri(uriString));
        }
    }

    //Grid.SetRow(newImage, ColumnCount);
    //Grid.SetColumn(newImage, ColumnCount);
    //grid_Main.Children.Add(newImage);
}
