using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _boardViewModel.MoveFromHeap(source, target);
                _heapViewModel.Remove(source);
            }
            else
            {
                _boardViewModel.MoveByBoard(source, target);
            }
        }
    }
}
