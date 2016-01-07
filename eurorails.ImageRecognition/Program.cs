using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
                    MassMin = 125,
                    MassMax = 340,
                    MeanRadiusMin = 3.5,
                    MeanRadiusMax = 8
                },
                new PatternMatcher
                {
                    Name = "Mountain",
                    MassMin = 350,
                    MassMax = 900,
                    MeanRadiusMin = 9,
                    MeanRadiusMax = 12
                },
                new PatternMatcher
                {
                    Name = "Alpine",
                    MassMin = 900,
                    MassMax = 1200,
                    MeanRadiusMin = 16,
                    MeanRadiusMax = 19
                },
                new PatternMatcher
                {
                    Name = "Small City",
                    MassMin = 2900,
                    MassMax = 4010,
                    MeanRadiusMin = 20,
                    MeanRadiusMax = 25
                },
                new PatternMatcher
                {
                    Name = "Medium City",
                    MassMin = 4010,
                    MassMax = 5300,
                    MeanRadiusMin = 24,
                    MeanRadiusMax = 40
                },
                new PatternMatcher
                {
                    Name = "Major City",
                    MassMin = 25000,
                    MassMax = 50000,
                    MeanRadiusMin = 70,
                    MeanRadiusMax = 80
                }
            };

            var nonMatchedPattern = new PatternMatcher
            {
                Name = "None"
            };

            var bitmap = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "board_min_1bit_inverted.bmp")));
            //var bitmap = new Bitmap(Image.FromFile(Path.Combine(OutputFolder, "None_20.bmp")));

            Console.WriteLine("Loaded bitmap, splitting to Blobs");

            var blobs = bitmap.SplitToBlobs(80);

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

            var digests = new List<string> {"Item\tX\tY\tMass\tMeanRadius\tMedianRadius"};
            
            foreach (var item in output)
            {
                Console.WriteLine("Outputting {0}", item.Key.Name);

                var sortedList = item.Value.OrderByDescending(a => a.Mass).ToList();
                for (var i = 0; i < sortedList.Count; ++i)
                {
                    var message = new StringBuilder()
                        .Append(item.Key.Name)
                        .Append(i)
                        .Append("\t")
                        .Append(sortedList[i].CentroidX)
                        .Append("\t")
                        .Append(sortedList[i].CentroidY)
                        .Append("\t")
                        .Append(sortedList[i].Mass)
                        .Append("\t")
                        .Append(Math.Round(sortedList[i].MeanRadius, 3))
                        .Append("\t")
                        .Append(Math.Round(sortedList[i].MedianRadius, 3))
                        .ToString();

                    Console.WriteLine(message);
                    digests.Add(message);

                    var xOffset = sortedList[i].OriginalBlob.Points.Min(a => a.Location.X);
                    var yOffset = sortedList[i].OriginalBlob.Points.Min(a => a.Location.Y);
                    var length = sortedList[i].OriginalBlob.Points.Max(a => a.Location.X) + 1;
                    var height = sortedList[i].OriginalBlob.Points.Max(a => a.Location.Y) + 1;

                    Console.WriteLine("{0} of {1}: {2} x {3} pixels", i, item.Value.Count, length - xOffset, height - yOffset);

                    var outputBitmap = new Bitmap(length - xOffset, height - yOffset);
                    foreach (var p in sortedList[i].OriginalBlob.Points)
                    {
                        outputBitmap.SetPixel(p.Location.X - xOffset, p.Location.Y - yOffset, p.Color);
                    }
                    outputBitmap.Save(Path.Combine(OutputFolder, item.Key.Name + "_" + i + ".bmp"));
                }
            }

            File.WriteAllLines(Path.Combine(OutputFolder, Guid.NewGuid().ToString() + ".txt"), digests);

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
