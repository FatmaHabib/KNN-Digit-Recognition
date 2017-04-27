using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_Pattern_Project
{
    class DigitImage
    {
        public byte[,] pixels;
        public byte label;

        public DigitImage(byte[,] pixels, byte label)
        {
            this.pixels = new byte[28, 28];

            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    this.pixels[i, j] = pixels[i, j];

            this.label = label;
        }

    }
}
