using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class SerializedMilepost
    {
        public Guid Id { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }

        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public string Ocean { get; set; }
    }

    public class SerializedMilepostConnection
    {
        public Guid Id { get; set; }

        public Guid MilepostId1 { get; set; }
        public Guid MilepostId2 { get; set; }

        public List<string> RiversCrossed { get; set; }
        public bool HasLakeOrInlet { get; set; }
    }

    public class SerializedFerryConnection
    {
        public Guid MilepostId1 { get; set; }
        public Guid MilepostId2 { get; set; }

        public string FerryType { get; set; }
        public int Cost { get; set; }
    }
}
