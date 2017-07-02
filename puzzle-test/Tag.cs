using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle_test
{
    class Tag
    {
        public string ImagePath { get; set; }
        public int RequiredPosition;
        public bool IsEmpty { get; set; }

        public Tag()
        {
            ImagePath = "./img/empty.png";
            IsEmpty = true;
            RequiredPosition = -1;
        }
    }
}
