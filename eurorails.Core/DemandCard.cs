using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class DemandCard
    {
        public readonly ICollection<LoadDemand> Loads;
        public readonly int CardId;

        public DemandCard(int cardId, params LoadDemand[] loads)
        {
            CardId = cardId;
            Loads = loads;
        }
    }

    public class LoadDemand
    {
        public readonly string ResourceName;
        public readonly string TargetCity;
        public readonly int Payout;

        public LoadDemand(string resourceName, string targetCity, int payout)
        {
            ResourceName = resourceName;
            TargetCity = targetCity;
            Payout = payout;
        }
    }
}
