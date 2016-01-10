using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eurorails.Core.Config;

namespace eurorails.ImageRecognition
{
    public static class MajorCityOutpostJammer
    {
        public static IEnumerable<LinkedSerializedMilepost> AddMajorCityOutposts(this IEnumerable<LinkedSerializedMilepost> mileposts, double majorCityOutpostDistance)
        {
            foreach (var m in mileposts)
            {
                yield return m;

                if (m.Type != "Major City")
                {
                    continue;
                }

                for (var i = 0; i < 6; ++i)
                {
                    var x = m.LocationX + (majorCityOutpostDistance * Math.Cos(i * Math.PI / 3));
                    var y = m.LocationY + (majorCityOutpostDistance * Math.Sin(i * Math.PI / 3));

                    yield return new LinkedSerializedMilepost
                    {
                        Connections = new List<SerializedMilepostConnection>(),
                        LocationX = x,
                        LocationY = y,
                        Type = "Major City Outpost",
                        Id = Guid.NewGuid()
                    };
                }
            }
        }
    }
}
