using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class EventCards
    {
        public static readonly IReadOnlyCollection<EventCard> Values = new EventCard[]
        {
            new TeamstersStrikeEventCard(),
            new LongshoremanStrikeEventCard(),
            new WildcatStrikeEventCard(),
            new ExcessProfitsTaxEventCard(),
            new HeavySnowEventCard(151, "Torino", 6, true),
            new HeavySnowEventCard(152, "Munchen", 5),
            new HeavySnowEventCard(153, "Praha", 4),
            new HeavySnowEventCard(154, "Krakow", 6),
            new FogEventCard(),
            new FloodEventCard(156, "Rhein"),
            new FloodEventCard(157, "Donau"),
            new FloodEventCard(158, "Ebro"),
            new GalesEventCard(159, "Atlantic Ocean"),
            new GalesEventCard(160, "Mediterranean Sea", "Adriatic Sea"),
            new GalesEventCard(161, "North Sea", "Irish Sea", "English Channel"),
            new DerailmentsEventCard(162, "Glasgow", "Ruhr", "Zurich", "Barcelona", "Cork", "Lisboa"),
            new DerailmentsEventCard(163, "Oslo", "Berlin", "Torino", "Napoli", "Sevilla", "Cardiff"),
            new DerailmentsEventCard(164, "Aberdeen", "Hamburg", "Sarajevo", "Porto", "Stuttgart", "Paris"),
            new DerailmentsEventCard(165, "London", "Arhus", "Lodz", "Venezia", "Belfast", "Frankfurt"),
            new DerailmentsEventCard(166, "Szczecin", "Dublin", "Kaliningrad", "Wien", "Toulouse", "Newcastle"),
            new ToolingNeededEventCard(),
            new IrishEconomyBoomingEventCard()
        };
    }
}
