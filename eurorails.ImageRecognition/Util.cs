using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public static class Util
    {
        public static double AbsMin(params double[] inputs)
        {
            return inputs.Select(Math.Abs).Min();
        }

        public static double Median(this ICollection<double> input)
        {
            var midpoint = input.Count / 2;
            if (input.Count % 2 == 1)
            {
                ++midpoint;
            }
            return input.OrderBy(a => a).ElementAt(midpoint);
        }

        public static double TotalBrightness(this Color color)
        {
            return color.GetBrightness() * color.A / 255D;
        }

    }
}
