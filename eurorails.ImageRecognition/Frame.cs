using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public class Frame
    {
        public bool IsProcessed { get; private set; }

        private readonly Bitmap _bitmap;
        private readonly int _xOffset;
        private readonly int _yOffset;
        private readonly int _xLength;
        private readonly int _yLength;

        public double CentroidX { get; private set; }
        public double CentroidY { get; private set; }
        public double Mass { get; private set; }
        public double MeanRadius { get; private set; }
        public double MedianRadius { get; private set; }
        public double MeanPadding { get; private set; }
        public double MedianPadding { get; private set; }

        public Frame(Bitmap bitmap, int xOffset, int yOffset, int xLength, int yLength)
        {
            _bitmap = bitmap;
            _xOffset = xOffset;
            _yOffset = yOffset;
            _xLength = xLength;
            _yLength = yLength;

            IsProcessed = false;
        }

        public void Process()
        {
            var points = SerializeBitmap();
            var colorDigest = DigestColors(points);
            var filtered = FilterEmpty(colorDigest);
            Finalize(filtered);

            IsProcessed = true;
        }

        private IEnumerable<ColorPoint> SerializeBitmap()
        {
            for (var i = 0; i < _xLength; ++i)
            {
                for (var j = 0; j < _yLength; ++j)
                {
                    var location = new Point(i, j);

                    if (i + _xOffset > _bitmap.Width
                        || j + _yOffset > _bitmap.Height)
                    {
                        yield return new ColorPoint(Color.Transparent, location);
                    }
                    else
                    {
                        yield return new ColorPoint(_bitmap.GetPixel(i, j), location);
                    }
                }
            }
        }

        private IEnumerable<ColorPointBrightnessIndex> DigestColors(IEnumerable<ColorPoint> colorPoints)
        {
            foreach (var c in colorPoints)
            {
                yield return new ColorPointBrightnessIndex(c.Location.X, c.Location.Y, GetTotalBrightnessCoefficient(c.Color));
            }
        }

        private IEnumerable<ColorPointBrightnessIndex> FilterEmpty(IEnumerable<ColorPointBrightnessIndex> input)
        {
            return input.Where(a => a.Mass > 0);
        }

        private static double GetTotalBrightnessCoefficient(Color color)
        {
            return color.GetBrightness() * color.A / 255D;
        }

        private void Finalize(IEnumerable<ColorPointBrightnessIndex> brightnesses)
        {
            var mass = 0D;
            var xAggregate = 0D;
            var yAggregate = 0D;
            var inputs = new List<ColorPointBrightnessIndex>();

            foreach (var c in brightnesses)
            {
                mass += c.Mass;
                xAggregate += c.X;
                yAggregate += c.Y;

                inputs.Add(c);
            }

            if (mass == 0)
            {
                return;
            }

            Mass = mass;
            CentroidX = xAggregate / mass;
            CentroidY = yAggregate / mass;

            var radiusComponents = new List<double>();
            var paddingComponents = new List<double>();

            foreach (var c in inputs)
            {
                var radius = Math.Sqrt(Math.Pow(c.X - CentroidX, 2) + Math.Pow(c.Y - CentroidY, 2));
                var weighted = radius * c.Mass;
                radiusComponents.Add(weighted);

                paddingComponents.Add(AbsMin(c.X - _xOffset, c.X - (_xOffset + _xLength),
                                             c.Y - _yOffset, c.Y - (_yOffset + _yLength)));
            }

            MeanRadius = radiusComponents.Average();
            MedianRadius = Median(radiusComponents);
            MeanPadding = paddingComponents.Average();
            MedianPadding = Median(paddingComponents);
        }

        private static double AbsMin(params double[] inputs)
        {
            return inputs.Select(Math.Abs).Min();
        }

        private static double Median(ICollection<double> input)
        {
            var midpoint = input.Count / 2;
            if (input.Count % 2 == 1)
            {
                ++midpoint;
            }
            return input.OrderBy(a => a).ElementAt(midpoint);
        }

        private class ColorPoint
        {
            public readonly Color Color;
            public readonly Point Location;

            public ColorPoint(Color color, Point location)
            {
                Color = color;
                Location = location;
            }
        }

        private class ColorPointBrightnessIndex
        {
            public readonly double X;
            public readonly double Y;
            public readonly double Mass;

            public ColorPointBrightnessIndex(double x, double y, double mass)
            {
                X = x;
                Y = y;
                Mass = mass;
            }
        }
    }
}
