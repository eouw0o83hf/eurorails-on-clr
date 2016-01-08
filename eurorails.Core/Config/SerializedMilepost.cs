using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class SerializedMilepost
    {
        public string Type { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public List<SerializedMilepostConnection> Connections { get; set; }
    }

    public class SerializedMilepostConnection
    {
        public double Milepost1LocationX { get; set; }
        public double Milepost1LocationY { get; set; }
        public double Milepost2LocationX { get; set; }
        public double Milepost2LocationY { get; set; }
    }
}
