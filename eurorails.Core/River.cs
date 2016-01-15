using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class River
    {
        public string Name { get; set; }
        public ICollection<LandMilepostConnection> Crossings { get; set; }
    }
}
