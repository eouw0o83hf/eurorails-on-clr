using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public static class BlobAnalyzer
    {
        public static BlobAnalysisResult Analyze(this BlobContainer blob,
                                                int? frameXOffset = null, int? frameYOffset = null,
                                                int? frameXLength = null, int? frameYLength = null)
        {
            var mass = 0D;
            var xAggregate = 0D;
            var yAggregate = 0D;

            foreach (var c in blob.Points)
            {
                mass += c.Color.TotalBrightness();
                xAggregate += c.Location.X;
                yAggregate += c.Location.Y;
            }

            if (mass == 0)
            {
                return null;
            }

            var response = new BlobAnalysisResult
            {
                Mass = mass,
                CentroidX = xAggregate / mass,
                CentroidY = yAggregate / mass
            };

            var radiusComponents = new List<double>();
            var paddingComponents = new List<double>();

            var xOffset = frameXOffset ?? blob.Points.Min(a => a.Location.X);
            var yOffset = frameYOffset ?? blob.Points.Min(a => a.Location.Y);
            var xLength = frameXLength ?? (blob.Points.Max(a => a.Location.X) - xOffset);
            var yLength = frameYLength ?? (blob.Points.Max(a => a.Location.Y) - yOffset);

            foreach (var c in blob.Points)
            {
                var radius = Math.Sqrt(Math.Pow(c.Location.X - response.CentroidX, 2) + Math.Pow(c.Location.Y - response.CentroidY, 2));
                var weighted = radius * c.Color.TotalBrightness();
                radiusComponents.Add(weighted);

                paddingComponents.Add(Util.AbsMin(c.Location.X - xOffset, c.Location.X - (xOffset + xLength),
                                                  c.Location.Y - yOffset, c.Location.Y - (yOffset + yLength)));
            }

            response.MeanRadius = radiusComponents.Average();
            response.MedianRadius = radiusComponents.Median();
            response.MeanPadding = paddingComponents.Average();
            response.MedianPadding = paddingComponents.Median();

            return response;
        }
    }

    public class BlobAnalysisResult
    {
        public double CentroidX { get; set; }
        public double CentroidY { get; set; }
        public double Mass { get; set; }
        public double MeanRadius { get; set; }
        public double MedianRadius { get; set; }
        public double MeanPadding { get; set; }
        public double MedianPadding { get; set; }
    }
}
