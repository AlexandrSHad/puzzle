using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace puzzle_test
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _mainViewModel;
        }

        private void ItemControlBoard_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Image img = (Image)e.OriginalSource;

                if (img == null)
                {
                    return;
                }

                Tag tag = img.DataContext as Tag;

                if (tag == null)
                {
                    return;
                }

                if (!tag.IsEmpty)
                {
                    DataObject drugData = new DataObject(tag);

                    DragDrop.DoDragDrop(img, drugData, DragDropEffects.Move);
                }
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.BoardViewModel.Tags[0].CurrentPosition = 8;
            _mainViewModel.BoardViewModel.Tags[8].CurrentPosition = 0;
        }

        private void ItemControlBoard_Drop(object sender, DragEventArgs e)
        {
            Image droppedImage = e.OriginalSource as Image;

            if (droppedImage == null)
            {
                return;
            }

            Tag droppedTag = droppedImage.DataContext as Tag;

            if (droppedTag == null)
            {
                return;
            }

            if (e.Data.GetDataPresent(typeof(Tag)))
            {
                Tag draggedTag = (Tag)e.Data.GetData(typeof(Tag));

                _mainViewModel.MoveByBoard(draggedTag, droppedTag);
            }
        }

        private void ItemControlBoard_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            Image img = e.OriginalSource as Image;

            if (img == null)
            {
                return;
            }

            Tag tag = img.DataContext as Tag;

            if (tag.IsEmpty)
            {
                e.Effects = DragDropEffects.Move;
            }

            e.Handled = true;
        }
    }
}
