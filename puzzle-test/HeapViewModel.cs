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
    class HeapViewModel
    {
        private readonly int BOARD_SIZE = 3;
        private ObservableCollection<Tag> _tags = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> Tags
        {
            get { return _tags; }
        }

        public HeapViewModel()
        {
            CreateTags();
            Shuffle();
        }

        internal void Shuffle()
        {
            int n = _tags.Count;
            while (n > 1)
            {
                var rng = new Random();

                n--;
                int k = rng.Next(n + 1);
                Tag value = _tags[k];
                _tags[k] = _tags[n];
                _tags[n] = value;
            }
        }

        internal void Remove(Tag source)
        {
            _tags.Remove(source);
        }


        #region Helpers

        private void CreateTags()
        {
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
            {
                Tag newTag = new Tag( i, String.Format("./img/puzzle01/{0:D3}.png", i+1));
                _tags.Add(newTag);
            }
        }

        #endregion Helpers
    }
}
