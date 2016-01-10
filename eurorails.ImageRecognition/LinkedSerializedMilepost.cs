using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eurorails.Core.Config;
using Newtonsoft.Json;

namespace eurorails.ImageRecognition
{
    public class LinkedSerializedMilepost : SerializedMilepost
    {
        [JsonIgnore]
        public List<SerializedMilepostConnection> Connections { get; set; }
    }

    public class LinkedSerializedMilepostConnection : SerializedMilepostConnection
    {
        [JsonIgnore]
        public SerializedMilepost Milepost1 { get; set; }

        [JsonIgnore]
        public SerializedMilepost Milepost2 { get; set; }
    }
}
