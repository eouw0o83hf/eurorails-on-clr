using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public static class BitmapParser
    {
        public static IEnumerable<ColorPoint> ParseBitmap(this Bitmap bitmap,
                                                            int? frameXLength = null, int? frameYLength = null,
                                                            int? frameXOffset = null, int? frameYOffset = null,
                                                            bool errorOnBitmapOverrun = false)
        {
            var xLength = frameXLength ?? bitmap.Width;
            var yLength = frameYLength ?? bitmap.Height;
            var xOffset = frameXOffset ?? 0;
            var yOffset = frameYOffset ?? 0;

            for (var i = 0; i < xLength - 1; ++i)
            {
                for (var j = 0; j < yLength - 1; ++j)
                {
                    var location = new Point(i, j);

                    if (i + xOffset > bitmap.Width
                        || j + yOffset > bitmap.Height)
                    {
                        if (errorOnBitmapOverrun)
                        {
                            throw new ArgumentException("Ran off the end of the bitmap trying to access (" + i + ", " + j + ")");
                        }
                        yield return new ColorPoint(Color.Transparent, location);
                    }
                    else
                    {
                        yield return new ColorPoint(bitmap.GetPixel(i, j), location);
                    }
                }
            }
        }
    }

    public class ColorPoint
    {
        public readonly Color Color;
        public readonly Point Location;

        public ColorPoint(Color color, Point location)
        {
            Color = color;
            Location = location;
        }
    }
}
