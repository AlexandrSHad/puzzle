using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<Tag> Tags { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Tags = new ObservableCollection<Tag>()
            {
                new Tag() {ImagePath = "./img/1.png", RequiredPosition = 0, CurrentPosition = 0},
                new Tag() {ImagePath = "./img/2.png", RequiredPosition = 1, CurrentPosition = 1},
                new Tag() {ImagePath = "./img/3.png", RequiredPosition = 2, CurrentPosition = 2},
                new Tag() {ImagePath = "./img/4.png", RequiredPosition = 3, CurrentPosition = 3},
                new Tag() {ImagePath = "./img/5.png", RequiredPosition = 4, CurrentPosition = 4},
                new Tag() {ImagePath = "./img/6.png", RequiredPosition = 5, CurrentPosition = 5},
                new Tag() {ImagePath = "./img/7.png", RequiredPosition = 6, CurrentPosition = 6},
                new Tag() {ImagePath = "./img/8.png", RequiredPosition = 7, CurrentPosition = 7},
                new Tag() {ImagePath = "./img/9.png", RequiredPosition = 8, CurrentPosition = 8}
            };

            //Tags.Move(0, 8);

            DataContext = Tags;

            //Tags[0].currentPosition = 8;
            //Tags[8].currentPosition = 0;

            //itemsControl.ItemsSource = Tags;
        }

        private void ItemControlBoard_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //MessageBox.Show("Drug: "+e.Source.ToString());
                //MessageBox.Show(itemControl.Sel);
                Image img = (Image)e.OriginalSource;

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

                DataObject drugData = new DataObject(img.DataContext);

                DragDrop.DoDragDrop(img, drugData, DragDropEffects.Move);
            }
        }

        private void ItemControlBoard_Drop(object sender, DragEventArgs e)
        {
            Image img = (Image)e.OriginalSource;

            Tag existingTag = img.DataContext as Tag;

            if (e.Data.GetDataPresent(typeof(Tag)))
            {
                int tempPosition = existingTag.CurrentPosition;

                Tag droppedTag = e.Data.GetData(typeof(Tag)) as Tag;

                existingTag.CurrentPosition = droppedTag.CurrentPosition;

                droppedTag.CurrentPosition = tempPosition;
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            Tags[0].CurrentPosition = 8;
            Tags[8].CurrentPosition = 0;
            //NotifyPropertyChanged("Tags");
        }



        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //protected void NotifyPropertyChanged(string propertyName)
        //{
        //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
    }

    public class Tag : INotifyPropertyChanged
    {
        int _currentPosition;
        public string ImagePath { get; set; }
        public int CurrentPosition {
            get { return _currentPosition; }
            set
            {
                _currentPosition = value;
                NotifyPropertyChanged("currentRow");
                NotifyPropertyChanged("currentColumn");
            }
        }
        public int RequiredPosition { get; set; }

        public int CurrentRow
        {
            get
            {
                return _currentPosition / 3;
            }
        }
        public int CurrentColumn
        {
            get
            {
                return _currentPosition % 3;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
