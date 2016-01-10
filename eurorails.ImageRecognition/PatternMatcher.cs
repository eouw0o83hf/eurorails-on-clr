using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.ImageRecognition
{
    public class PatternMatcher
    {
        public string Name { get; set; }

        public double? MassMin { get; set; }
        public double? MassMax { get; set; }

        public double? MeanRadiusMin { get; set; }
        public double? MeanRadiusMax { get; set; }

        public double? MedianRadiusMin { get; set; }
        public double? MedianRadiusMax { get; set; }

        public bool Matches(BlobAnalysisResult result)
        {
            if (MassMin.HasValue && result.Mass < MassMin.Value)
            {
                return false;
            }

            if (MassMax.HasValue && result.Mass > MassMax.Value)
            {
                return false;
            }

            if (MeanRadiusMin.HasValue && result.MeanRadius < MeanRadiusMin.Value)
            {
                return false;
            }

            if (MeanRadiusMax.HasValue && result.MeanRadius > MeanRadiusMax.Value)
            {
                return false;
            }

            if (MedianRadiusMin.HasValue && result.MedianRadius < MedianRadiusMin.Value)
            {
                return false;
            }

            if (MedianRadiusMax.HasValue && result.MedianRadius > MedianRadiusMax.Value)
            {
                return false;
            }

            return true;
        }
    }
}
