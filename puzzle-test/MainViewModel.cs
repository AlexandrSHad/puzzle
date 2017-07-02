﻿using System;
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

        public MainViewModel()
        {

        }

        public void MoveByBoard(int from, int to)
        {
            _boardViewModel.Move(from, to);
        }
    }
}
