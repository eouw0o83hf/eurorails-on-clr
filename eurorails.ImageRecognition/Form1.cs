﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            var milepostSample = Path.Combine(InputFolder, "patch_milepostwithriver.bmp");
            var milepostImage = Image.FromFile(milepostSample);
            var milepostBitmap = new Bitmap(milepostImage);

            var blobs = milepostBitmap.SplitToBlobs();
            var digests = new List<string>();

            foreach (var x in blobs)
            {
                var milepostFrame = x.Analyze(0, 0, milepostBitmap.Width, milepostBitmap.Height);
                digests.Add(new StringBuilder()
                    .Append(Math.Round(milepostFrame.CentroidX, 3))
                    .Append("\t")
                    .Append(Math.Round(milepostFrame.CentroidY, 3))
                    .Append("\t")
                    .Append(milepostFrame.Mass)
                    .Append("\t")
                    .Append(Math.Round(milepostFrame.MeanPadding, 3))
                    .Append("\t")
                    .Append(milepostFrame.MedianPadding)
                    .Append("\t")
                    .Append(Math.Round(milepostFrame.MeanRadius, 3))
                    .Append("\t")
                    .Append(Math.Round(milepostFrame.MedianRadius, 3))
                    .ToString());
            }

            pictureBox1.Image = milepostImage;
        }
    }
}
