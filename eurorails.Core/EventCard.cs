using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class EventCard : Card
    {
        protected EventCard(int cardId)
            : base(cardId) { }
    }

    public class HeavySnowEventCard : EventCard
    {
        // All trains within `MilepostRadius` of `City` move at half rate.
        // No movement or rail building is allowed in the `AlpineRestriction ? alpine : string.Empty`
        // mileposts of this area.

        public readonly string City;
        public readonly int MilepostRadius;
        public readonly bool AlpineRestriction;

        public HeavySnowEventCard(int cardId, string city, int milepostRadius, bool alpineRestriction = false)
            : base(cardId)
        {
            City = city;
            MilepostRadius = milepostRadius;
            AlpineRestriction = alpineRestriction;
        }
    }

    public class FogEventCard : EventCard
    {
        // All trains within 4 milepost of FRANKFURT move at half rate
        // No rail building is allowed in this area

        public FogEventCard()
            : base(155) { }
    }

    public class DerailmentsEventCard : EventCard
    {
        // Any train within 3 mileposts of `Cities` losts 1 turn and 1 load.

        public readonly ICollection<string> Cities;

        public DerailmentsEventCard(int cardId, params string[] cities)
            : base(cardId)
        {
            Cities = cities;
        }
    }

    public class GalesEventCard : EventCard
    {
        // All trains within 4 mileposts of the `BodiesOfWater` move at half rate.
        // No rail building and no ferry movement is allowed in this area.

        public readonly ICollection<string> BodiesOfWater;

        public GalesEventCard(int cardId, params string[] bodiesOfWater)
            : base(cardId)
        {
            BodiesOfWater = bodiesOfWater;
        }
    }

    public class FloodEventCard : EventCard
    {
        // No train may cross the `RiverName` river.
        // All bridges over this river are destroyed.

        public readonly string RiverName;

        public FloodEventCard(int cardId, string riverName)
            : base(cardId)
        {
            RiverName = riverName;
        }
    }

    public class WildcatStrikeEventCard : EventCard
    {
        // No train may move on the drawing player's rail lines.
        // The drawing player may not build track

        public WildcatStrikeEventCard()
            : base(149) { }
    }

    public class LongshoremanStrikeEventCard : EventCard
    {
        // No train may pick up from or deliver to any city within 3 mileposts of any coast

        public LongshoremanStrikeEventCard()
            : base(148) { }
    }

    public class TeamstersStrikeEventCard : EventCard
    {
        // No train may pick up from or deliver to any city more than 3 mileposts from any coast
        
        public TeamstersStrikeEventCard()
            : base(147) { }
    }

    public class IrishEconomyBoomingEventCard : EventCard
    {
        // Irish Economy growing fast.
        // The next delivery to IRELAND receives an extra 10 million.
        // This card stays in effect until used.

        public IrishEconomyBoomingEventCard()
            : base(168) { }
    }

    public class ToolingNeededEventCard : EventCard
    {
        // High demand for new tooling.
        // The next delivery of MACHINERY receives an extra 10 million.
        // This card stays in effect until used.

        public ToolingNeededEventCard()
            : base(167) { }
    }

    public class ExcessProfitsTaxEventCard : EventCard
    {
        // Each player must pay tax.
        // Players' cash is now public information.

        public ExcessProfitsTaxEventCard()
            : base(150) { }

        public int GetTaxAmount(int cash)
        {
            if (cash <= 49) return 0;
            if (cash <= 99) return 10;
            if (cash <= 149) return 15;
            if (cash <= 199) return 20;
            if (cash <= 249) return 25;
            return 30;
        }
    }
}
