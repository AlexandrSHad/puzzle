using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace puzzle_test
{
    class MainViewModel
    {
        private readonly BoardViewModel _boardViewModel = new BoardViewModel();
            public BoardViewModel BoardViewModel
            {
                get { return _boardViewModel; }
            }

        private readonly HeapViewModel _heapViewModel = new HeapViewModel();
            public HeapViewModel HeapViewModel
            {
                get { return _heapViewModel; }
            }

        public void Move(Tag source, Tag target)
        {
            if (source.CurrentPosition == -1)
            {
                MoveFromHeap(source, target);
            }
            else
            {
                MoveByBoard(source, target);
            }

            CheckForWin();
        }

        private void MoveFromHeap(Tag source, Tag target)
        {
            _boardViewModel.MoveFromHeap(source, target);
            _heapViewModel.Remove(source);
        }

        private void MoveByBoard(Tag source, Tag target)
        {
            _boardViewModel.MoveByBoard(source, target);
        }

        private void CheckForWin()
        {
            if (_boardViewModel.CheckForWin())
            {
                MessageBox.Show("Congratulation! You are a winner.");
            }
        }
    }
}
