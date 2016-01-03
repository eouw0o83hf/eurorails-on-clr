using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eurorails.ImageRecognition
{
    public class Program
    {
        const string InputFolder = @"..\..\..\Images\";
        const string OutputFolder = @"..\..\..\Images\Output";

        public static void Main(string[] args)
        {
            var patterns = new[]
            {
                new PatternMatcher
                {
                    Name = "Milepost",
                    MassMin = 225,
                    MassMax = 275,
                    MeanRadiusMin = 5,
                    MeanRadiusMax = 8
                },
                new PatternMatcher
                {
                    Name = "Mountain",
                    MassMin = 600,
                    MassMax = 850,
                    MeanRadiusMin = 9,
                    MeanRadiusMax = 12
                },
                new PatternMatcher
                {
                    Name = "Alpine",
                    MassMin = 1000,
                    MassMax = 1200,
                    MeanRadiusMin = 15,
                    MeanRadiusMax = 19
                },
                new PatternMatcher
                {
                    Name = "Small City",
                    MassMin = 3000,
                    MassMax = 4000,
                    MeanRadiusMin = 20,
                    MeanRadiusMax = 25
                },
                new PatternMatcher
                {
                    Name = "Medium City",
                    MassMin = 4000,
                    MassMax = 5300,
                    MeanRadiusMin = 24,
                    MeanRadiusMax = 30
                }
            };

            var nonMatchedPattern = new PatternMatcher
            {
                Name = "None"
            };

            var bitmap = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "board_min_1bit_inverted_cropped.bmp")));

            Console.WriteLine("Loaded bitmap, splitting to Blobs");

            var blobs = bitmap.SplitToBlobs();

            Console.WriteLine("Split to {0} Blobs", blobs.Count);

            var output = new Dictionary<PatternMatcher, List<BlobAnalysisResult>>();

            foreach (var b in blobs)
            {
                var analysis = b.Analyze(0, 0, bitmap.Width, bitmap.Height);
                var match = patterns.FirstOrDefault(a => a.Matches(analysis)) ?? nonMatchedPattern;
                if (!output.ContainsKey(match))
                {
                    output[match] = new List<BlobAnalysisResult>();
                }
                output[match].Add(analysis);
            }

            Console.WriteLine("Done pattern matching, outputting blobs");

            foreach (var item in output)
            {
                Console.WriteLine("Outputting {0}", item.Key.Name);

                for (var i = 0; i < item.Value.Count; ++i)
                {
                    var xOffset = item.Value[i].OriginalBlob.Points.Min(a => a.Location.X);
                    var yOffset = item.Value[i].OriginalBlob.Points.Min(a => a.Location.Y);
                    var length = item.Value[i].OriginalBlob.Points.Max(a => a.Location.X);
                    var height = item.Value[i].OriginalBlob.Points.Max(a => a.Location.Y);

                    Console.WriteLine("{0} of {1}: {2} x {3} pixels", i, item.Value.Count, length - xOffset, height - yOffset);

                    var outputBitmap = new Bitmap(length - xOffset, height - yOffset);
                    foreach (var p in item.Value[i].OriginalBlob.Points)
                    {
                        outputBitmap.SetPixel(p.Location.X - xOffset, p.Location.Y - yOffset, p.Color);
                    }
                    //for (var x = 0; x < length - xOffset; ++x)
                    //{
                    //    for (var y = 0; y < height - yOffset; ++y)
                    //    {
                    //        var pixel = item.Value[i].OriginalBlob.Points.FirstOrDefault(a => a.Location.X == x + xOffset && a.Location.Y == y + yOffset);
                    //        if (pixel != null)
                    //        {
                    //            outputBitmap.SetPixel(x, y, pixel.Color);
                    //        }
                    //        else
                    //        {
                    //            outputBitmap.SetPixel(x, y, Color.Black);
                    //        }
                    //    }
                    //}
                    outputBitmap.Save(Path.Combine(OutputFolder, item.Key.Name + "_" + i + ".bmp"));
                }
            }

            Console.WriteLine("Done!");
            Console.Read();

            //var milepostSample = Path.Combine(InputFolder, "patch_milepostwithriver.bmp");
            //var milepostImage = Image.FromFile(milepostSample);
            //var milepostBitmap = new Bitmap(milepostImage);

            //var blobs = milepostBitmap.SplitToBlobs();
            //var digests = new List<string>();

            //foreach (var x in blobs)
            //{
            //    var milepostFrame = x.Analyze(0, 0, milepostBitmap.Width, milepostBitmap.Height);
            //    digests.Add(new StringBuilder()
            //        .Append(Math.Round(milepostFrame.CentroidX, 3))
            //        .Append("\t")
            //        .Append(Math.Round(milepostFrame.CentroidY, 3))
            //        .Append("\t")
            //        .Append(milepostFrame.Mass)
            //        .Append("\t")
            //        .Append(Math.Round(milepostFrame.MeanPadding, 3))
            //        .Append("\t")
            //        .Append(milepostFrame.MedianPadding)
            //        .Append("\t")
            //        .Append(Math.Round(milepostFrame.MeanRadius, 3))
            //        .Append("\t")
            //        .Append(Math.Round(milepostFrame.MedianRadius, 3))
            //        .ToString());
            //}

            //pictureBox1.Image = milepostImage;
        }
    }
}
