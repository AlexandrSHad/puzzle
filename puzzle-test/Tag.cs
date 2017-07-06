using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle_test
{
    public class Tag : INotifyPropertyChanged
    {
        public Tag(int currentPosition)
        {
            ImagePath = "./img/empty.png";
            IsEmpty = true;
            _currentPosition = currentPosition;
            RequiredPosition = -1;
        }

        public string ImagePath { get; set; }
        public bool IsEmpty { get; set; }
        public int RequiredPosition { get; set; }

        int _currentPosition;
            public int CurrentPosition
            {
                get { return _currentPosition; }
                set
                {
                    _currentPosition = value;
                    NotifyPropertyChanged("currentRow");
                    NotifyPropertyChanged("currentColumn");
                }
            }

        //TODO: delete this two methods and create Converter for cast _currentPosition to Row and Column
        public int CurrentRow
        {
            get
            {
                return _currentPosition / 3;
            }
        }
        public int CurrentColumn
        {
            get
            {
                return _currentPosition % 3;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
