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
    public class EventCardTests
    {
        [Test]
        public void EventCardConfig_ShouldHaveIdsFrom147To168()
        {
            var count = EventCards
                        .Values
                        .Select(a => a.CardId)
                        .Distinct()
                        .Count(a => a >= 147 && a <= 168);
            Assert.That(count, Is.EqualTo(22));
        }

        [Test]
        public void EventCardConfig_SnowCards_ShouldMatchCityNames()
        {
            var cards = EventCards
                        .Values
                        .OfType<HeavySnowEventCard>();
            foreach (var c in cards)
            {
                Assert.That(CityResources.Values.ContainsKey(c.City), c.City);
            }
        }

        [Test]
        public void EventCardConfig_DerailmentCards_ShouldMatchCityNames()
        {
            var cards = EventCards
                        .Values
                        .OfType<DerailmentsEventCard>();
            foreach (var c in cards)
            {
                foreach (var d in c.Cities)
                {
                    Assert.That(CityResources.Values.ContainsKey(d), d);
                }
            }
        }

        [Test]
        public void EventCardConfig_FloodCards_ShouldMatchConnectionRiverNames()
        {
            var cards = EventCards
                .Values
                .OfType<FloodEventCard>();
            var connectionRivers = Connections
                .Values
                .Where(a => a.RiversCrossed != null)
                .SelectMany(a => a.RiversCrossed)
                .Distinct()
                .ToList();

            foreach (var c in cards)
            {
                CollectionAssert.Contains(connectionRivers, c.RiverName);
            }
        }

        [Test]
        public void EventCardConfig_GalesCards_ShouldMatchMilepostBodyOfWaterNames()
        {
            var cards = EventCards
                .Values
                .OfType<GalesEventCard>();
            var bodiesOfWater = Mileposts
                .Values
                .Where(a => !string.IsNullOrWhiteSpace(a.Ocean))
                .Select(a => a.Ocean)
                .Distinct()
                .ToList();

            foreach (var c in cards)
            {
                foreach (var b in c.BodiesOfWater)
                {
                    CollectionAssert.Contains(bodiesOfWater, b);
                }
            }
        }
    }
}
