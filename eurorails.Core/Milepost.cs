using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class Milepost
    {
        public ICollection<Milepost> AdjacentMileposts { get; set; }
        public ICollection<string> AdjacentBodiesOfWater { get; set; }
    }

    public class MountainMilepost : Milepost
    {
    }

    public class AlpineMountainMilepost : Milepost
    {
    }
}
