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
        public static ICollection<BlobContainer> SplitToBlobs(this Bitmap bitmap, int? minimumBlobMass = 3)
        {
            var nonEmptyPixels = bitmap.ParseBitmap()
                                       .Where(a => a.Color.TotalBrightness() > 0.5);

            var blobs = new List<BlobContainer>();
            var blobMap = new Dictionary<Point, BlobContainer>();

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

                var matchingBlobs = adjacentPoints
                                    .Where(blobMap.ContainsKey)
                                    .Select(a => blobMap[a])
                                    .Distinct();

                BlobContainer targetBlob = null;
                foreach (var m in matchingBlobs)
                {
                    if (targetBlob == null)
                    {
                        targetBlob = m;
                    }
                    else
                    {
                        foreach (var l in m.Points)
                        {
                            targetBlob.Points.Add(l);
                            blobMap[l.Location] = targetBlob;
                            blobs.Remove(m);
                        }
                    }
                }
                if (targetBlob == null)
                {
                    targetBlob = new BlobContainer
                    {
                        Points = new List<ColorPoint>()
                    };
                    blobs.Add(targetBlob);
                }
                targetBlob.Points.Add(locus);
                blobMap[locus.Location] = targetBlob;
            }

            if (minimumBlobMass.HasValue)
            {
                blobs.RemoveAll(a => a.Points.Count < minimumBlobMass.Value);
            }
            return blobs;
        }
    }

    public class BlobContainer
    {
        public List<ColorPoint> Points { get; set; }
    }
}
