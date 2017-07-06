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
        int _currentPosition;
        public string ImagePath { get; set; }
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
        public int RequiredPosition { get; set; }

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
