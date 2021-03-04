using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpMemory
{
    public class Card
    {
        public string ShownImage { get; set; }
        public string HiddenImage { get; set; }
        public bool Turned { get; set; }
        public bool Solved { get; set; }

        public Card(string hiddenImage)
        {
            ShownImage = "/Images/image000.jpg";
            HiddenImage = hiddenImage;
            Turned = false;
            Solved = false;
        }
    }
}
