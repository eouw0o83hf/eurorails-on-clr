using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eurorails.ImageRecognition
{
    public partial class Form1 : Form
    {
        const string InputFolder = @"..\..\..\Images\";

        public Form1()
        {
            InitializeComponent();
            
            var inputImage = Image.FromFile(InputFolder + "board_min_1bit_inverted_cropped.bmp");
            pictureBox1.Image = inputImage;

            var nonBlackPixels = new List<Point>();
            var bitmap = new Bitmap(inputImage);

            for (var i = 0; i < bitmap.Width; ++i)
            {
                for (var j = 0; j < bitmap.Height; ++j)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel.GetBrightness() > 0.5)
                    {
                        nonBlackPixels.Add(new Point(i, j));
                    }
                }
            }
        }
    }
}
