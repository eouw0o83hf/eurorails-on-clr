using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public class ResourceBank
    {
        private static readonly IReadOnlyDictionary<string, int> ResourceNumbers = new Dictionary<string, int>
        {
            { "Bauxite", 3 },
            { "Beer", 4 },
            { "Cars", 3 },
            { "Cattle", 3 },
            { "Cheese", 4 },
            { "China", 3 },
            { "Chocolate", 3 },
            { "Coal", 3 },
            { "Copper", 3 },
            { "Cork", 3 },
            { "Fish", 3 },
            { "Flowers", 3 },
            { "Ham", 3 },
            { "Hops", 3 },
            { "Imports", 3 },
            { "Iron", 3 },
            { "Labor", 3 },
            { "Machinery", 4 },
            { "Marble", 3 },
            { "Oil", 4 },
            { "Oranges", 3 },
            { "Potatoes", 3 },
            { "Sheep", 3 },
            { "Steel", 3 },
            { "Tobacco", 3 },
            { "Tourists", 3 },
            { "Wheat", 3 },
            { "Wine", 4 },
            { "Wood", 3 }
        };
    }
}
