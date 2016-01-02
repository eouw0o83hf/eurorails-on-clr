using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class CityResources
    {
        public static readonly IReadOnlyDictionary<string, ICollection<string>> Values = new Dictionary<string, ICollection<string>>
        {
            { "Aberdeen", new [] { "Fish", "Oil" } },
            { "Antwerpen", new [] { "Imports" } },
            { "Arhus", new [] { "Cheese" } },
            { "Barcelona", new [] { "Machinery" } },
            { "Belfast", new [] { "Potatoes" } },
            { "Beograd", new [] { "Copper", "Oil", "Labor" } },
            { "Berlin", new string[0] },
            { "Bern", new [] { "Cattle", "Cheese" } },
            { "Bilbao", new [] { "Sheep" } },
            { "Birmingham", new [] { "China", "Iron", "Steel" } },
            { "Bordeaux", new [] { "Wine" } },
            { "Bremen", new [] { "Machinery" } },
            { "Bruxelles", new [] { "Chocolate" } },
            { "Budapest", new [] { "Bauxite" } },
            { "Cardiff", new [] { "Coal", "Hops" } },
            { "Cork", new [] { "Sheep" } },
            { "Dublin", new [] { "Beer" } },
            { "Firenze", new [] { "Marble" } },
            { "Frankfurt", new [] { "Beer", "Wine" } },
            { "Glasgow", new [] { "Sheep" } },
            { "Goteborg", new [] { "Machinery" } },
            { "Hamburg", new [] { "Imports" } },
            { "Holland", new [] { "Cheese", "Flowers" } },
            { "Kaliningrad", new [] { "Iron" } },
            { "Kobenhavn", new [] { "Cheese" } },
            { "Krakow", new [] { "Coal" } },
            { "Leipzig", new [] { "China" } },
            { "Lisboa", new [] { "Cork" } },
            { "Lodz", new [] { "Potatoes" } },
            { "London", new [] { "Tourists" } },
            { "Luxembourg", new [] { "Steel" } },
            { "Lyon", new [] { "Wheat" } },
            { "Madrid", new string[0] },
            { "Manchester", new [] { "Cars" } },
            { "Marseille", new [] { "Bauxite" } },
            { "Milano", new string[0] },
            { "Munchen", new [] { "Beer", "Cars" } },
            { "Nantes", new [] { "Cattle", "Machinery" } },
            { "Napoli", new [] { "Tobacco" } },
            { "Newcastle", new [] { "Oil" } },
            { "Oslo", new [] { "Wood", "Oil", "Fish" } },
            { "Paris", new string[0] },
            { "Porto", new [] { "Fish", "Wine" } },
            { "Praha", new [] { "Beer" } },
            { "Roma", new string[0] },
            { "Ruhr", new [] { "Tourists", "Steel" } },
            { "Sarajevo", new [] { "Labor", "Wood" } },
            { "Sevilla", new [] { "Cork", "Oranges" } },
            { "Stockholm", new [] { "Iron", "Wood" } },
            { "Stuttgart", new [] { "Cars" } },
            { "Szczecin", new [] { "Potatoes" } },
            { "Torino", new [] { "Cars" } },
            { "Toulouse", new [] { "Wine" } },
            { "Valencia", new [] { "Oranges" } },
            { "Venezia", new string[0] },
            { "Warszawa", new [] { "Ham" } },
            { "Wien", new [] { "Wine" } },
            { "Wroclaw", new [] { "Coal", "Copper" } },
            { "Zagreb", new [] { "Labor" } },
            { "Zurich", new [] { "Chocolate" } }
        };
    }
}
