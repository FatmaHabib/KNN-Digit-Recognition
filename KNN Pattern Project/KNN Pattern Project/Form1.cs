using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN_Pattern_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadingInput Read = new ReadingInput();
            Read.Reading_Data_Training();
            Read.Reading_Data_Test();
            MessageBox.Show("Trainning set and Test set is loaded");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(28, 28);
            int index = Convert.ToInt32(textBox2.Text);
            index--;
            if (index >= 0 && index < 10000)
            {
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 28; j++)
                    {
                        image.SetPixel(j, i, Color.FromArgb(ReadingInput.TestImages[index].pixels[i, j], ReadingInput.TestImages[index].pixels[i, j], ReadingInput.TestImages[index].pixels[i, j]));
                    }
                }
                pictureBox1.Image = image;

            }

             index = Convert.ToInt32(textBox2.Text);
            index--;
            if (index >= 0 && index < 10000 && Convert.ToInt32(textBox3.Text) <= 60000)
            {
                byte pred= K_Nearest_Neighbour.Classify(ReadingInput.TestImages[index], ReadingInput.TrainImages, Convert.ToInt32(textBox2.Text));
                textBox1  .Text = pred.ToString();
            }
        }
    }
}
