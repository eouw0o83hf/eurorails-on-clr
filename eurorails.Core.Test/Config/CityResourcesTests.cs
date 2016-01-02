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
    public class CityResourcesTests
    {
        [Test]
        public void ResourceNames_ShouldMatchResourceCountNames()
        {
            foreach (var c in CityResources.Values)
            {
                foreach (var r in c.Value)
                {
                    Assert.That(ResourceCounts.Values.ContainsKey(r));
                }
            }
        }
    }
}
