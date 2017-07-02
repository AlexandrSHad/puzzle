using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace puzzle_test
{
    class BoardViewModel : IEnumerable<Tag>
    {
        private readonly int BOARD_SIZE = 3;
        private List<Tag> _tags = new List<Tag>();

        public BoardViewModel()
        {
            CreateTags();
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return _tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Tag this[int index]
        {
            get { return _tags[index]; }
        }
        
        #region Helpers

        private void CreateTags()
        {
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
            {
                _tags.Add(new Tag());
            }
        }

        #endregion Helpers
    }
}
