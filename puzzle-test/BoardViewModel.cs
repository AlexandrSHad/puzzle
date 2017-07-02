using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace puzzle_test
{
    class BoardViewModel : IEnumerable<Tag>
    {
        private readonly int BOARD_SIZE = 3;
        private ObservableCollection<Tag> _tags = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> Tags
        {
            get { return _tags; }
        }

        public BoardViewModel()
        {
            CreateTags();
        }

        public void Move(int colFrom, int rowFrom, int colTo, int rowTo)
        {
            int from = GetPosition(colFrom, rowFrom);
            int to = GetPosition(colTo, rowTo);

            Tag tempTag = _tags[to];
            _tags[to] = _tags[from];
            _tags[from] = tempTag;
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return _tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //public Tag this[int index]
        //{
        //    get { return _tags[index]; }
        //}

        #region Helpers

        private void CreateTags()
        {
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
            {
                _tags.Add(new Tag());
            }

            _tags[0].RequiredPosition = 0;
            _tags[0].ImagePath = "./img/1.png";
            _tags[0].IsEmpty = false;

            _tags[1].RequiredPosition = 0;
            _tags[1].ImagePath = "./img/2.png";
            _tags[1].IsEmpty = false;

            //Move(0, 8);
        }

        private int GetPosition(int col, int row)
        {
            return BOARD_SIZE * row + col;
        }

        #endregion Helpers
    }
}
