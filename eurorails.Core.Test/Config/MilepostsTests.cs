using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eurorails.Core.Config;
using NUnit.Framework;

namespace eurorails.Core.Test.Config
{
    [TestFixture]
    public class MilepostsTests
    {
        [Test]
        public void CityMileposts_ShouldMatchACityResource()
        {
            var mileposts = Mileposts.Values;
            var cities = CityResources.Values;

            foreach (var m in mileposts)
            {
                if (!string.IsNullOrWhiteSpace(m.Name))
                {
                    Assert.That(cities.ContainsKey(m.Name), "Expected " + m.Name);
                }
            }
        }
    }
}
