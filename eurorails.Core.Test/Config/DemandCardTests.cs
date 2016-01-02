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
    public class DemandCardTests
    {
        [Test]
        public void DemandCardConfig_ShouldMatchResourceAndCityConfigs()
        {
            foreach (var card in DemandCards.Values)
            {
                foreach (var load in card.Loads)
                {
                    Assert.That(CityResources.Values.ContainsKey(load.TargetCity), load.TargetCity);
                    Assert.That(ResourceCounts.Values.ContainsKey(load.ResourceName), load.ResourceName);
                }
            }
        }
    }
}
