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

        private List<object> hitResultsList = new List<object>();

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
                //new Tag() {ImagePath = "./img/9.png", RequiredPosition = 8, CurrentPosition = 8}
            };

            //Tags.Move(0, 8);

            DataContext = Tags;

            //Tags[0].CurrentPosition = 8;
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {


            return; // RETURN


            
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // Set up a callback to receive the hit test result enumeration.
            HitTestResult hit = VisualTreeHelper.HitTest((UIElement)sender, pt);

            if (hit == null)
            {
                MessageBox.Show("null");
            }
            else
            {
                var img = hit.VisualHit as Image;

                if (img == null)
                {
                    MessageBox.Show("not image");
                }
                else
                {
                    MessageBox.Show(hit.VisualHit.ToString());
                }
            }

            // Perform actions on the hit test results list.
            //if (hitResultsList.Count > 0)
            //{
            //    Console.WriteLine("Number of Visuals Hit: " + hitResultsList.Count);
            //    foreach (object res in hitResultsList)
            //    {
            //        MessageBox.Show(res.ToString());
            //    }
            //}
        }

        // Return the result of the hit test to the callback.
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            // Add the hit test result to the list that will be processed after the enumeration.
            hitResultsList.Add(result.VisualHit);

            // Set the behavior to return visuals at all z-order levels.
            return HitTestResultBehavior.Continue;
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            //Point p = e.GetPosition((UIElement)sender);

            //HitTestResult result = VisualTreeHelper.HitTest((UIElement)sender, p);
            //DependencyObject control;
            //for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(itemsControl) - 1; i++)
            //{
            //    control = VisualTreeHelper.GetChild(itemsControl, i);
            //}

            Grid grid = FindVisualChild<Grid>(itemsControl);

            Point p = e.GetPosition(grid);

            int col, row;

            getPosition(grid, p, out col, out row);

            Tag tag = e.Data.GetData(typeof(Tag)) as Tag;
            tag.CurrentPosition = row * 3 + col;
        }

        public void getPosition(Grid grid, Point point, out int col, out int row)
        {
            //DControl control = parent as DControl;
            //var point = Mouse.GetPosition(element);
            row = 0;
            col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // calc row mouse was over
            foreach (var rowDefinition in grid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
        }

        public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }

                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }

        private void Window_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            Point p = e.GetPosition((UIElement)sender);

            HitTestResult hit = VisualTreeHelper.HitTest((UIElement)sender, p);

            if (hit != null)
            {
                if (!(hit.VisualHit is Image))
                {
                    e.Effects = DragDropEffects.Move;
                }
            }

            e.Handled = true;
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
