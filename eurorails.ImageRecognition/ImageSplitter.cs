using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public static class ImageSplitter
    {
        public static ICollection<BlobContainer> SplitToBlobs(this Bitmap bitmap)
        {
            var nonEmptyPixels = bitmap.ParseBitmap()
                                       .Where(a => a.Color.TotalBrightness() > 0.5);

            var blobs = new List<BlobContainer>();
            foreach (var locus in nonEmptyPixels)
            {
                Console.WriteLine("Parsing ({0}, {1})", locus.Location.X, locus.Location.Y);

                var adjacentPoints = new List<Point>();
                if (locus.Location.X > 0)
                {
                    adjacentPoints.Add(new Point(locus.Location.X - 1, locus.Location.Y));
                }
                if (locus.Location.Y > 0)
                {
                    adjacentPoints.Add(new Point(locus.Location.X, locus.Location.Y - 1));
                }
                if (locus.Location.X < bitmap.Width - 1)
                {
                    adjacentPoints.Add(new Point(locus.Location.X + 1, locus.Location.Y));
                }
                if (locus.Location.Y < bitmap.Height - 1)
                {
                    adjacentPoints.Add(new Point(locus.Location.X, locus.Location.Y + 1));
                }

                var matchingBlobs = blobs.Where(a => a.Points.Any(b => adjacentPoints.Contains(b.Location))).ToList();


                BlobContainer targetBlob;
                if (matchingBlobs.Any())
                {
                    targetBlob = matchingBlobs.First();
                    foreach (var r in matchingBlobs.Skip(1))
                    {
                        targetBlob.Points.AddRange(r.Points);
                        blobs.Remove(r);
                    }
                }
                else
                {
                    targetBlob = new BlobContainer
                    {
                        Points = new List<ColorPoint>()
                    };
                    blobs.Add(targetBlob);
                }
                targetBlob.Points.Add(locus);
            }
            return blobs;
        }
    }

    public class BlobContainer
    {
        public List<ColorPoint> Points { get; set; }
    }
}
