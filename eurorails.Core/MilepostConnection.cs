using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public abstract class MilepostConnection
    {
        public Milepost Milepost1 { get; set; }
        public Milepost Milepost2 { get; set; }
    }

    public class LandMilepostConnection : MilepostConnection
    {
        public List<River> RiversCrossed { get; set; }
        public bool CrossesBayOrInlet { get; set; }
    }

    public class FerryMilepostConnection : MilepostConnection
    {
        public int Cost { get; set; }
    }

    public class ChunnelMilepostConnection : MilepostConnection
    {
        public const int Cost = 20;
    }
}
