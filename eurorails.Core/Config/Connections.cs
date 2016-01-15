using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eurorails.Core.Config
{
    public static class Connections
    {
        public static readonly ICollection<SerializedMilepostConnection> Values;

        static Connections()
        {
            var assembly = Assembly.GetAssembly(typeof(Mileposts));
            const string resourceName = "eurorails.Core.Config.Config_Connections.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                Values = JsonConvert.DeserializeObject<ICollection<SerializedMilepostConnection>>(result);
            }
        }

        public static MilepostConnection Import(this SerializedMilepostConnection connection, 
                                                IDictionary<Guid, Milepost> milepostMap,
                                                ICollection<River> rivers)
        {
            var riversCrossed = (from r in connection.RiversCrossed
                                 join v in rivers on r equals v.Name
                                 select v).ToList();

            var response = new LandMilepostConnection
            {
                CrossesBayOrInlet = connection.HasLakeOrInlet,
                RiversCrossed = riversCrossed,
                Milepost1 = milepostMap[connection.MilepostId1],
                Milepost2 = milepostMap[connection.MilepostId2]
            };

            response.Milepost1.AddConnection(response);
            response.Milepost2.AddConnection(response);
            foreach (var r in response.RiversCrossed)
            {
                r.AddCrossing(response);
            }

            return response;
        }

        private static void AddConnection(this Milepost milepost, MilepostConnection connection)
        {
            if (milepost.Connections == null)
            {
                milepost.Connections = new List<MilepostConnection>();
            }
            milepost.Connections.Add(connection);
        }

        private static void AddCrossing(this River river, LandMilepostConnection connection)
        {
            if (river.Crossings == null)
            {
                river.Crossings = new List<LandMilepostConnection>();
            }
            river.Crossings.Add(connection);
        }
    }
}
