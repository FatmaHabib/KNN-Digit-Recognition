using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_Pattern_Project
{
    static class K_Nearest_Neighbour
    {
        public static int[] testResults;
        public static int[,] confusionMatrix;
        static int Compare(KeyValuePair<double, byte> a, KeyValuePair<double, byte> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        public static byte Classify(DigitImage digitImage, List<DigitImage> trainingSet, int k)
        {
            int[] count = new int[10];
            List<KeyValuePair<double, byte>> sortedDiff = new List<KeyValuePair<double, byte>>();
            foreach (DigitImage trainingImage in trainingSet)
            {
                double diff = 0.0f;
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 28; j++)
                    {
                        diff += (digitImage.pixels[i, j] - trainingImage.pixels[i, j]) * (digitImage.pixels[i, j] - trainingImage.pixels[i, j]);
                    }
                }
                diff = Math.Sqrt(diff);
                KeyValuePair<double, byte> p = new KeyValuePair<double, byte>(diff, trainingImage.label);
                sortedDiff.Add(p);
            }
            int index = 0;
            sortedDiff.Sort(Compare);
            foreach (KeyValuePair<double, byte> diff in sortedDiff)
            {
                count[diff.Value]++;
                index++;
                if (index == k)
                    break;
            }
            int max = 0;
            byte Class = 0;
            for (byte i = 0; i < 10; i++)
            {
                if (count[i] > max)
                {
                    Class = i;
                    max = count[i];
                }
            }
            return Class;
        }

        public static double Classify(int l, int r, List<DigitImage> testSet, List<DigitImage> trainingSet, int k)
        {
            double correct = 0.0f;
            double size = 0.0f;
            testResults = new int[60002];
            confusionMatrix = new int[10, 10];
            DigitImage testImage;
            byte predicion;
            int testResultIndex = 0;
            for (int i = l; i <= r; i++)
            {
                testImage = testSet[i];
                predicion = Classify(testImage, trainingSet, k);
                if (predicion == testImage.label)
                    correct++;
                confusionMatrix[testImage.label, predicion]++;

                testResults[testResultIndex] = (int)(size + 1);

                testResultIndex++;
                testResults[testResultIndex] = testImage.label;
                testResultIndex++;
                testResults[testResultIndex] = predicion;
                testResultIndex++;
                size++;
            }
            double accuracy = (correct / size) * 100.0f;

            // testResults[(int)(size+1)]="Accuracy is : "+accuracy.ToString();
            //System.IO.File.WriteAllLines(@"C:\Users\omar\Desktop\testResults.txt", testResults);
            return accuracy;
        }
    }
}
