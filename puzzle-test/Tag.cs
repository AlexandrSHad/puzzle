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

        public Tag(int requiredPosition, string imagePath)
        {
            ImagePath = imagePath;
            IsEmpty = false;
            _currentPosition = -1;
            RequiredPosition = requiredPosition;
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
                    NotifyPropertyChanged("CurrentPosition");
                }
            }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
