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
            _mainViewModel.MoveByBoard(0, 0, 1, 1);

            //img5.Source = new BitmapImage(new Uri("/img/6.png", UriKind.Relative));
            //img6.Source = new BitmapImage(new Uri("/img/5.png", UriKind.Relative));
            //MessageBox.Show(img5.Source.BaseUri);
        }

        private void gridBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //MessageBox.Show("Drug");

                var img = e.Source as Image;

                //int col = Grid.GetColumn(img);
                //int row = Grid.GetRow(img);

                //DataObject dataObject = new DataObject(tag); // col + row

                DragDrop.DoDragDrop((Image)img, new DataObject(img), DragDropEffects.Move);

                //if (img == null)
                //{
                //    return;
                //}

                //var tag = img.DataContext as Tag;

                //if (tag != null)
                //{
                //    DataObject dataObject = new DataObject(tag);

                //    DragDrop.DoDragDrop((Image)img, dataObject, DragDropEffects.Move);
                //}


                //Image img = (Image)e.Source;

                //if (img.Source is BitmapImage)
                //{
                //    MessageBox.Show("BitmapImage");
                //    return;
                //}

                ////if (img.Source is BitmapFrame)
                ////{
                ////    MessageBox.Show("BitmapFrame");
                ////}

                //BitmapFrame bmp = (BitmapFrame)img.Source;
                //string uriString = bmp.Decoder.ToString();

                //DataObject drugData = new DataObject(uriString);

                //DragDrop.DoDragDrop(img, drugData, DragDropEffects.Move);
            }
        }

        private void gridBoard_Drop(object sender, DragEventArgs e)
        {
            var imgDrag = e.Data.GetData(typeof(Image)) as Image;
            var imgDrop = e.Source as Image;

            if ((imgDrag == null) || (imgDrop == null))
            {
                return;
            }

            int colFrom = Grid.GetColumn(imgDrag);
            int rowFrom = Grid.GetRow(imgDrag);

            int colTo = Grid.GetColumn(imgDrop);
            int rowTo = Grid.GetRow(imgDrop);

            _mainViewModel.MoveByBoard(colFrom, rowFrom, colTo, rowTo);

            //Image img = (Image)e.Source;
            //string uriString = (string)e.Data.GetData(typeof(string));
            //img.Source = new BitmapImage(new Uri(uriString));
        }
    }

    //Grid.SetRow(newImage, ColumnCount);
    //Grid.SetColumn(newImage, ColumnCount);
    //grid_Main.Children.Add(newImage);
}
