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
        public static List<SerializedMilepost> LinkMileposts(this List<SerializedMilepost> mileposts, double milepostThreshold)
        {
            for (var i = 0; i < mileposts.Count - 1; ++i)
            {
                for (var j = i + 1; j < mileposts.Count; ++j)
                {
                    var distance = Math.Sqrt(Math.Pow(mileposts[i].LocationX - mileposts[j].LocationX, 2) +
                                             Math.Pow(mileposts[i].LocationY - mileposts[j].LocationY, 2));

                    if (distance < milepostThreshold)
                    {
                        var link = new SerializedMilepostConnection
                        {
                            Milepost1LocationX = mileposts[i].LocationX,
                            Milepost1LocationY = mileposts[i].LocationY,
                            Milepost2LocationX = mileposts[j].LocationX,
                            Milepost2LocationY = mileposts[j].LocationY
                        };

                        mileposts[i].AddConnection(link);
                        mileposts[j].AddConnection(link);
                    }
                }
            }

            return mileposts;
        }

        private static void AddConnection(this SerializedMilepost milepost, SerializedMilepostConnection connection)
        {
            if (milepost.Connections == null)
            {
                milepost.Connections = new List<SerializedMilepostConnection>();
            }

            milepost.Connections.Add(connection);
        }
    }
}
