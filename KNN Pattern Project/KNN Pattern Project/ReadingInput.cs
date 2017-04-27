using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KNN_Pattern_Project
{
    class ReadingInput
    {
        public static List<DigitImage> TestImages;
        public static List<DigitImage> TrainImages;

        public void Reading_Data_Test()
        {

            TestImages = new List<DigitImage>();
            FileStream ifsLabels = new FileStream(@"t10k-labels.idx1-ubyte", FileMode.Open); // test labels
            FileStream ifsImages = new FileStream(@"t10k-images.idx3-ubyte", FileMode.Open); // test images

            BinaryReader brLabels = new BinaryReader(ifsLabels);
            BinaryReader brImages = new BinaryReader(ifsImages);

            int magic1 = brImages.ReadInt32();
            int numImages = brImages.ReadInt32();
            int numRows = brImages.ReadInt32();
            int numCols = brImages.ReadInt32();

            int magic2 = brLabels.ReadInt32();
            int numLabels = brLabels.ReadInt32();

            byte[,] pixels = new byte[28, 28];
            //for (int i = 0; i < pixels.Length; ++i)
            //    pixels[i] = new byte[28];

            // each test image
            for (int di = 0; di < 10000; ++di)
            {
                for (int i = 0; i < 28; ++i)
                {
                    for (int j = 0; j < 28; ++j)
                    {
                        byte b = brImages.ReadByte();
                        pixels[i, j] = b;
                    }
                }

                byte lbl = brLabels.ReadByte();

                DigitImage dImage = new DigitImage(pixels, lbl);
                TestImages.Add(dImage);
            }

            ifsImages.Close();
            brImages.Close();
            ifsLabels.Close();
            brLabels.Close();
        }

        public  void Reading_Data_Training()
        {

            TrainImages = new List<DigitImage>();
             FileStream ifsLabels = new FileStream(@"train-labels.idx1-ubyte", FileMode.Open); // test labels
                FileStream ifsImages = new FileStream(@"train-images.idx3-ubyte", FileMode.Open); // test images

                BinaryReader brLabels = new BinaryReader(ifsLabels);
                BinaryReader brImages = new BinaryReader(ifsImages);

                int magic1 = brImages.ReadInt32(); // discard
                int numImages = brImages.ReadInt32();
                int numRows = brImages.ReadInt32();
                int numCols = brImages.ReadInt32();

                int magic2 = brLabels.ReadInt32();
                int numLabels = brLabels.ReadInt32();

                byte[,] pixels = new byte[28, 28];
                //for (int i = 0; i < pixels.Length; ++i)
                //    pixels[i] = new byte[28];

                // each test image
                for (int di = 0; di < 60000; ++di)
                {
                    for (int i = 0; i < 28; ++i)
                    {
                        for (int j = 0; j < 28; ++j)
                        {
                            byte b = brImages.ReadByte();
                            pixels[i, j] = b;
                        }
                    }

                    byte lbl = brLabels.ReadByte();

                    DigitImage dImage = new DigitImage(pixels, lbl);
                    TrainImages.Add(dImage);
                }

                ifsImages.Close();
                brImages.Close();
                ifsLabels.Close();
                brLabels.Close();
        }
    }
}
