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
    public static class Mileposts
    {
        public static readonly ICollection<SerializedMilepost> Values;

        static Mileposts()
        {
            var assembly = Assembly.GetAssembly(typeof(Mileposts));
            const string resourceName = "eurorails.Core.Config.Config_Mileposts.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                Values = JsonConvert.DeserializeObject<ICollection<SerializedMilepost>>(result);
            }
        }

        public static Milepost Convert(this SerializedMilepost input)
        {
            Milepost response;
            switch (input.Type)
            {
                case "Major City":
                case "Major City Outpost":
                    response = new MajorCity(input.Name);
                    break;

                case "Medium City":
                    response = new MediumCity(input.Name);
                    break;

                case "Small City":
                    response = new SmallCity(input.Name);
                    break;

                case "Mountain":
                    response = new MountainMilepost();
                    break;

                case "Alpine":
                    response = new AlpineMountainMilepost();
                    break;

                case "Milepost":
                    response = new Milepost();
                    break;

                default:
                    throw new InvalidDataException("Couldn't instantiate a Milepost of type " + input.Type);
            }

            response.AdjacentBodyOfWater = input.Ocean;
            return response;
        }
    }
}
