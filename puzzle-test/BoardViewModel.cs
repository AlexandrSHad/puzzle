﻿using System;
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

        public void MoveByBoard(Tag source, Tag target)
        {
            int tempPosition = source.CurrentPosition;
            source.CurrentPosition = target.CurrentPosition;
            target.CurrentPosition = tempPosition;
        }

        internal void MoveFromHeap(Tag source, Tag target)
        {
            source.CurrentPosition = target.CurrentPosition;
            _tags.Remove(target);
            _tags.Add(source);
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return _tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #region Helpers

        private void CreateTags()
        {
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
            {
                _tags.Add(new Tag(i)); // TODO: create tags with Enumerable.Zip() method
            }

            _tags[0].RequiredPosition = 0;
            _tags[0].ImagePath = "./img/1.png";
            _tags[0].IsEmpty = false;

            _tags[1].RequiredPosition = 0;
            _tags[1].ImagePath = "./img/2.png";
            _tags[1].IsEmpty = false;
        }

        #endregion Helpers
    }
}
