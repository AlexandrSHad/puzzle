﻿using System.Windows;
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

        // TODO: create class for Drag and Drop command binding as Attached Behavior rather then this three methods
        private void Board_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Tag draggedTag = GetRelationTag(e.OriginalSource);

                if (draggedTag == null)
                {
                    return;
                }

                if (!draggedTag.IsEmpty)
                {
                    DataObject dragData = new DataObject(draggedTag);

                    DragDrop.DoDragDrop((UIElement)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }
        }

        private void Board_Drop(object sender, DragEventArgs e)
        {
            Tag targetTag = GetRelationTag(e.OriginalSource);

            if (targetTag == null)
            {
                return;
            }

            if (e.Data.GetDataPresent(typeof(Tag)))
            {
                Tag draggedTag = (Tag)e.Data.GetData(typeof(Tag));

                _mainViewModel.Move(draggedTag, targetTag);
            }
        }

        private void Board_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            Tag targetTag = GetRelationTag(e.OriginalSource);

            if (targetTag.IsEmpty)
            {
                e.Effects = DragDropEffects.Move;
            }

            e.Handled = true;
        }

        private void Heap_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Tag draggedTag = GetRelationTag(e.OriginalSource);

                if (draggedTag == null)
                {
                    return;
                }

                DataObject dragData = new DataObject(draggedTag);

                DragDrop.DoDragDrop((UIElement)e.OriginalSource, dragData, DragDropEffects.Move);
            }
        }

        #region Helpers

        private Tag GetRelationTag(object control)
        {
            Image img = control as Image;

            if (img == null)
            {
                return null;
            }

            return img.DataContext as Tag;
        }

        #endregion Helpers
    }
}
