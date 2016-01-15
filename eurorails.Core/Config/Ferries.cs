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
    public static class Ferries
    {
        public static readonly ICollection<SerializedFerryConnection> Values;

        static Ferries()
        {
            var assembly = Assembly.GetAssembly(typeof(Mileposts));
            const string resourceName = "eurorails.Core.Config.Config_Ferries.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                Values = JsonConvert.DeserializeObject<ICollection<SerializedFerryConnection>>(result);
            }
        }

        public static FerryMilepostConnection Import(this SerializedFerryConnection connection, IDictionary<Guid, Milepost> milepostMap)
        {
            var response = new FerryMilepostConnection
            {
                Cost = connection.Cost,
                Milepost1 = milepostMap[connection.MilepostId1],
                Milepost2 = milepostMap[connection.MilepostId2]
            };

            response.Milepost1.AddConnection(response);
            response.Milepost2.AddConnection(response);

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
    }
}
