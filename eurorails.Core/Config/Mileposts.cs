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
    public class Mileposts
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
    }
}
