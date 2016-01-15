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

        [Test]
        public void Connections_ShouldMatchMileposts()
        {
            foreach (var c in Connections.Values)
            {
                Assert.That(Mileposts.Values.Any(a => a.Id == c.MilepostId1));
                Assert.That(Mileposts.Values.Any(a => a.Id == c.MilepostId2));
            }
        }

        [Test]
        public void Ferries_ShouldMatchMileposts()
        {
            foreach (var f in Ferries.Values)
            {
                Assert.That(Mileposts.Values.Any(a => a.Id == f.MilepostId1));
                Assert.That(Mileposts.Values.Any(a => a.Id == f.MilepostId2));
            }
        }

        [Test]
        public void Mileposts_ShouldInstantiateCorrectly()
        {
            foreach (var m in Mileposts.Values)
            {
                Assert.DoesNotThrow(() => m.Convert());
            }
        }
    }
}
