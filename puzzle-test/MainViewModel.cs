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

        public void MoveByBoard(Tag source, Tag target)
        {
            _boardViewModel.Move(source, target);
        }
    }
}
