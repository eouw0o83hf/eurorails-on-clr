using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eurorails.Core;
using eurorails.Core.Config;
using Newtonsoft.Json;

namespace eurorails.ImageRecognition
{
    public class Program
    {
        const string InputFolder = @"..\..\..\Images\";
        const string OutputFolder = @"..\..\..\Images\Output";

        // Used to read an image into json config
        public static void Main_Load(string[] args)
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
            var board = new List<SerializedMilepost>();

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

                    if (!item.Key.Name.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    {
                        board.Add(new SerializedMilepost
                        {
                            Type = item.Key.Name,
                            LocationX = sortedList[i].CentroidX,
                            LocationY = sortedList[i].CentroidY
                        });
                    }
                }
            }

            var serialized = JsonConvert.SerializeObject(board);
            File.WriteAllText(Path.Combine(InputFolder, "Mileposts.json"), serialized);

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

        // Used to validate the json config and link mileposts
        public static void Main_Link(string[] args)
        {
            const double milepostDistanceThreshold = 170;
            const double majorCityOutpostDistance = 123;

            var milepostSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_milepost.bmp")));
            var smallCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_smallcity.bmp")));
            var medCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_mediumcity.bmp")));
            var majorCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_majorcity.bmp")));
            var mountainSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_mountain.bmp")));
            var alpineSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_alpine.bmp")));
            var outpostSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_outpost.bmp")));

            var typeDictionary = new Dictionary<string, Bitmap>
            {
                {"Milepost", milepostSample},
                {"Small City", smallCitySample},
                {"Medium City", medCitySample},
                {"Major City", majorCitySample},
                {"Mountain", mountainSample},
                {"Alpine", alpineSample},
                {"Major City Outpost", outpostSample}
            };

            var input = JsonConvert
                .DeserializeObject<List<LinkedSerializedMilepost>>(
                    File.ReadAllText(Path.Combine(InputFolder, "Mileposts.json")));
            input.ForEach(a => a.Id = Guid.NewGuid());
            
            var width = (int) Math.Ceiling(input.Max(a => a.LocationX));
            var height = (int) Math.Ceiling(input.Max(a => a.LocationY));

            Console.WriteLine("Linking {0} mileposts", input.Count);

            input = input
                        .AddMajorCityOutposts(majorCityOutpostDistance)
                        .OrderBy(a => a.LocationX)
                        .ThenBy(a => a.LocationY)
                        .ToList()
                        .LinkMileposts(milepostDistanceThreshold);

            var output = new Bitmap(width, height);
            using (Graphics graph = Graphics.FromImage(output))
            {
                var ImageSize = new Rectangle(0, 0, output.Width, output.Height);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }

            Console.WriteLine("writing {0} mileposts", input.Count);
            foreach (var item in input)
            {
                var sample = typeDictionary[item.Type];

                for (var i = 0; i < sample.Width; ++i)
                {
                    for (var j = 0; j < sample.Height; ++j)
                    {
                        // Assume these are reasonably centered
                        var x = (i - (sample.Width / 2)) + (int)item.LocationX;
                        var y = (j - (sample.Height / 2)) + (int)item.LocationY;

                        if (x >= output.Width || y >= output.Height)
                        {
                            continue;
                        }

                        output.SetPixel(x, y, sample.GetPixel(i, j));
                    }
                }
            }

            Console.WriteLine("Generating paths for links");
            var links = input
                        .Where(a => a.Connections != null)
                        .SelectMany(a => a.Connections)
                        .Where(a => a != null)
                        .Distinct()
                        .SelectMany(a => GenerateLinkPoints((LinkedSerializedMilepostConnection)a))
                        .Distinct()
                        .ToList();
            Console.WriteLine("writing {0} link points", links.Count);
            foreach (var link in links)
            {
                output.SetPixel(link.Point.X, link.Point.Y, link.Color);
            }

            output.Save(Path.Combine(InputFolder, "linked.bmp"));

            //var shortestConnections = input
            //    .Where(a => a.Connections != null)
            //    .SelectMany(a => a.Connections.Cast<LinkedSerializedMilepostConnection>())
            //    .Where(a => a != null)
            //    .Select(a => new
            //    {
            //        Distance = Math.Sqrt(
            //        Math.Pow(a.Milepost1.LocationX - a.Milepost2.LocationX, 2) +
            //        Math.Pow(a.Milepost2.LocationY - a.Milepost2.LocationY, 2)),
            //        Link = a
            //    })
            //    .OrderBy(a => a.Distance)
            //    .Take(10);

            //foreach (var s in shortestConnections)
            //{
            //    Console.WriteLine("Distance: {0} between {1},{2} and {3}{4}", s.Distance, s.Link.Milepost1.LocationX,
            //        s.Link.Milepost1.LocationY, s.Link.Milepost2.LocationX, s.Link.Milepost2.LocationY);
            //}
            
            File.WriteAllText(Path.Combine(InputFolder, "Config_Mileposts.json"), JsonConvert.SerializeObject(input));
            var connections = input
                .SelectMany(a => a.Connections)
                .Distinct()
                .ToList();
            File.WriteAllText(Path.Combine(InputFolder, "Config_Connections.json"), JsonConvert.SerializeObject(connections));

            Console.WriteLine("done");
            Console.Read();
        }

        public static void Main_Named(string[] args)
        {
            Console.WriteLine("Loading");

            var mileposts = JsonConvert.DeserializeObject<List<LinkedSerializedMilepost>>(File.ReadAllText(Path.Combine(InputFolder, "Config_Mileposts.json")));
            var links = JsonConvert.DeserializeObject<List<LinkedSerializedMilepostConnection>>(File.ReadAllText(Path.Combine(InputFolder, "Config_Connections.json")));

            Console.WriteLine("Linking");

            foreach (var l in links)
            {
                l.Milepost1 = mileposts.Single(a => a.Id == l.MilepostId1);
                l.Milepost2 = mileposts.Single(a => a.Id == l.MilepostId2);

                var m1 = (LinkedSerializedMilepost)l.Milepost1;
                if (m1.Connections == null) m1.Connections = new List<SerializedMilepostConnection>();
                m1.Connections.Add(l);

                var m2 = (LinkedSerializedMilepost)l.Milepost2;
                if (m2.Connections == null) m2.Connections = new List<SerializedMilepostConnection>();
                m2.Connections.Add(l);
            }

            var width = (int)Math.Ceiling(mileposts.Max(a => a.LocationX));
            var height = (int)Math.Ceiling(mileposts.Max(a => a.LocationY));

            var output = new Bitmap(width, height);
            using (var graph = Graphics.FromImage(output))
            {
                var ImageSize = new Rectangle(0, 0, output.Width, output.Height);
                graph.FillRectangle(Brushes.Black, ImageSize);
                
                var milepostSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_milepost.bmp")));
                var smallCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_smallcity.bmp")));
                var medCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_mediumcity.bmp")));
                var majorCitySample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_majorcity.bmp")));
                var mountainSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_mountain.bmp")));
                var alpineSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_alpine.bmp")));
                var outpostSample = new Bitmap(Image.FromFile(Path.Combine(InputFolder, "patch_outpost.bmp")));

                var typeDictionary = new Dictionary<string, Bitmap>
                {
                    {"Milepost", milepostSample},
                    {"Small City", smallCitySample},
                    {"Medium City", medCitySample},
                    {"Major City", majorCitySample},
                    {"Mountain", mountainSample},
                    {"Alpine", alpineSample},
                    {"Major City Outpost", outpostSample}
                };

                Console.WriteLine("Rendering mileposts");

                foreach (var item in mileposts)
                {
                    var sample = typeDictionary[item.Type];

                    for (var i = 0; i < sample.Width; ++i)
                    {
                        for (var j = 0; j < sample.Height; ++j)
                        {
                            // Assume these are reasonably centered
                            var x = (i - (sample.Width / 2)) + (int)item.LocationX;
                            var y = (j - (sample.Height / 2)) + (int)item.LocationY;

                            if (x >= output.Width || y >= output.Height)
                            {
                                continue;
                            }

                            var inputColor = sample.GetPixel(i, j);
                            var newColor = Color.FromArgb(inputColor.A/2, inputColor.R, inputColor.G, inputColor.B);

                            output.SetPixel(x, y, newColor);
                        }
                    }
                }

                foreach (var item in mileposts)
                {
                    graph.DrawString(item.Id.ToString().Substring(0, 7),
                        new Font(FontFamily.GenericMonospace, 16), new SolidBrush(Color.LightGreen),
                        new PointF((int)item.LocationX, (int)item.LocationY));
                }

                Console.WriteLine("Rendering link points");

                var linkPoints = links
                            .SelectMany(a => GenerateLinkPoints((LinkedSerializedMilepostConnection)a))
                            .Distinct()
                            .ToList();
            
                foreach (var link in linkPoints)
                {
                    output.SetPixel(link.Point.X, link.Point.Y, link.Color);
                }
            }
            //var allGuids = mileposts.Select(a => a.Id)
            //    .Concat(links.Select(a => a.Id))
            //    .Select(a => a.ToString().Substring(0, 7)) // 7-length gives a short guid
            //    .ToList();

            output.Save(Path.Combine(InputFolder, "labeled.bmp"));


            Console.WriteLine("Done");
            Console.Read();
        }

        // Attach names
        public static void Main(string[] args)
        {
            var mileposts = JsonConvert.DeserializeObject<List<LinkedSerializedMilepost>>(File.ReadAllText(Path.Combine(InputFolder, "Config_Mileposts.json")));

            var cityListing = new Dictionary<string, string>
            {
                {"540c262","Cork"},
                {"9f6f53d","Dublin"},
                {"6a01ec0","Belfast"},
                {"6d2adef","Aberdeen"},
                {"9be41f9","Glasgow"},
                {"279124e","Newcastle"},
                {"7251b8a","Manchester"},
                {"35a9341","Birmingham"},
                {"ac05b3b","Cardiff"},
                {"bfa9bd5","London"},
                {"a47479d","London"},
                {"fbff058","London"},
                {"fa1f6e9","London"},
                {"97217b0","London"},
                {"49dff88","London"},
                {"74f8649","London"},
                {"271983b","Holland"},
                {"c1c9ea4","Holland"},
                {"b956374","Holland"},
                {"ea4f99a","Holland"},
                {"39b2c86","Holland"},
                {"72453d3","Holland"},
                {"5f629dc","Holland"},
                {"4c32d05","Antwerpen"},
                {"052e89c","Bruxelles"},
                {"e6c72a5","Ruhr"},
                {"82d0a9d","Ruhr"},
                {"7ba5862","Ruhr"},
                {"a099089","Ruhr"},
                {"37f5705","Ruhr"},
                {"5af7d63","Ruhr"},
                {"c6fbacd","Ruhr"},
                {"5db635a","Paris"},
                {"0ce8719","Paris"},
                {"506a6dc","Paris"},
                {"7e16f13","Paris"},
                {"da04f55","Paris"},
                {"76101c6","Paris"},
                {"98401d9","Paris"},
                {"82e94a3","Luxemborg"},
                {"96260b3","Frankfurt"},
                {"4846a46","Bremen"},
                {"959c61b","Hamburg"},
                {"4a6541f","Arhus"},
                {"723557d","Kobenhavn"},
                {"3c3ad6e","Goteborg"},
                {"a4e4747","Stockholm"},
                {"0c40850","Oslo"},
                {"d81dd0c","Szczecin"},
                {"7b662fd","Kaliningrad"},
                {"dca0c49","Warszawa"},
                {"dc9abc6","Lodz"},
                {"c6c843e","Wroclaw"},
                {"50c2f1d","Berlin"},
                {"8f366c5","Berlin"},
                {"381ece1","Berlin"},
                {"15b9756","Berlin"},
                {"6674389","Berlin"},
                {"be998b3","Berlin"},
                {"c27cdab","Berlin"},
                {"46f414d","Leipzig"},
                {"36dc56e","Praha"},
                {"956de1b","Krakow"},
                {"7fe6898","Budapest"},
                {"f96e410","Beograd"},
                {"ea49212","Sarajevo"},
                {"6337cf7","Zagreb"},
                {"d6e876c","Wien"},
                {"fdd2d8b","Wien"},
                {"b46cf3a","Wien"},
                {"e191541","Wien"},
                {"f167313","Wien"},
                {"0ec8537","Wien"},
                {"3c6beeb","Wien"},
                {"7d1fbaa","Munchen"},
                {"2873895","Venezia"},
                {"40fe227","Florenze"},
                {"75cdbf5","Roma"},
                {"c5b8072","Milano"},
                {"d3a289e","Milano"},
                {"fe920fa","Milano"},
                {"ae446a0","Milano"},
                {"afe8dd1","Milano"},
                {"7f9ac9f","Milano"},
                {"5b1dac8","Milano"},
                {"cbdd857","Zurich"},
                {"6658cfa","Bern"},
                {"6dd37d3","Stuttgart"},
                {"93069c2","Torino"},
                {"6283e30","Lyon"},
                {"5c6860b","Marseille"},
                {"fb6b8ea","Barcelona"},
                {"4b37080","Toulouse"},
                {"a26f093","Bordeaux"},
                {"bdbc129","Nantes"},
                {"159f47c","Bilbao"},
                {"9899e3c","Valencia"},
                {"f3e6fc6","Madrid"},
                {"21ddfb1","Madrid"},
                {"90aefe2","Madrid"},
                {"dea2684","Madrid"},
                {"9960f30","Madrid"},
                {"ff1d9af","Madrid"},
                {"b0f4d8e","Madrid"},
                {"9aafb77","Porto"},
                {"fb25431","Lisboa"},
                {"050e6a8","Sevilla"}
            };

            var guidLookup = mileposts.ToDictionary(a => a.Id.ToString().Substring(0, 7), a => a);
            foreach (var a in cityListing)
            {
                guidLookup[a.Key].Name = a.Value;
            }


            File.WriteAllText(Path.Combine(InputFolder, "Config_Mileposts_Named.json"), JsonConvert.SerializeObject(mileposts));
        }

        private static IEnumerable<ContextualPoint> GenerateLinkPoints(LinkedSerializedMilepostConnection link)
        {
            var distance = Math.Sqrt(Math.Pow(link.Milepost1.LocationX - link.Milepost2.LocationX, 2) +
                                     Math.Pow(link.Milepost1.LocationY - link.Milepost2.LocationY, 2));
            var angle = Math.Asin((link.Milepost2.LocationY - link.Milepost1.LocationY) / distance);

            for (var i = 0; i <= distance; ++i)
            {
                var x = link.Milepost1.LocationX + (Math.Cos(angle) * i);
                var y = link.Milepost1.LocationY + (Math.Sin(angle) * i);
                var color = link.Milepost1.Type == "Major City Outpost" || link.Milepost2.Type == "Major City Outpost" ?
                    Color.Aqua : Color.Yellow;
                yield return new ContextualPoint {Point = new Point((int) x, (int) y), Color = color};
            }
        }

        private class ContextualPoint
        {
            public Point Point { get; set; }
            public Color Color { get; set; }
        }
    }
}
