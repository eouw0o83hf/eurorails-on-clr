using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eurorails.Core.Config;

namespace eurorails.ImageRecognition
{
    public static class MilepostLinker
    {
        public static List<LinkedSerializedMilepost> LinkMileposts(this List<LinkedSerializedMilepost> mileposts, double milepostThreshold)
        {
            for (var i = 0; i < mileposts.Count - 1; ++i)
            {
                for (var j = i + 1; j < mileposts.Count; ++j)
                {
                    var distance = Math.Sqrt(Math.Pow(mileposts[i].LocationX - mileposts[j].LocationX, 2) +
                                             Math.Pow(mileposts[i].LocationY - mileposts[j].LocationY, 2));

                    if (distance < milepostThreshold)
                    {
                        var link = new LinkedSerializedMilepostConnection
                        {
                            Milepost1 = mileposts[i],
                            Milepost2 = mileposts[j],
                            MilepostId1 = mileposts[i].Id,
                            MilepostId2 = mileposts[j].Id,
                            Id = Guid.NewGuid()
                        };

                        mileposts[i].AddConnection(link);
                        mileposts[j].AddConnection(link);
                    }
                }
            }

            return mileposts;
        }

        private static void AddConnection(this LinkedSerializedMilepost milepost, LinkedSerializedMilepostConnection connection)
        {
            if (milepost.Connections == null)
            {
                milepost.Connections = new List<SerializedMilepostConnection>();
            }

            milepost.Connections.Add(connection);
        }
    }
}
