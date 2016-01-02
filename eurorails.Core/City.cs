using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public abstract class City : Milepost
    {
        public readonly string Name;

        protected City(string name)
        {
            Name = name;
        }
    }

    public class SmallCity : City
    {
        public SmallCity(string name)
            : base(name) { }
    }

    public class MediumCity : City
    {
        public MediumCity(string name)
            : base(name) { }
    }

    public class MajorCity : City
    {
        public MajorCity(string name)
            : base(name) { }
    }
}
