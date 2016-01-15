using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class Milepost
    {
        public virtual int Cost { get { return 1; } }

        public string AdjacentBodyOfWater { get; set; }
        public ICollection<MilepostConnection> Connections { get; set; }
    }

    public class MountainMilepost : Milepost
    {
        public override int Cost { get { return 2; } }
    }

    public class AlpineMountainMilepost : Milepost
    {
        public override int Cost { get { return 5; } }
    }
}
