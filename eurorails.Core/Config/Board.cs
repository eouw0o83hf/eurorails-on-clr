using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class Board
    {
        public static readonly ICollection<Milepost> BoardMileposts;
        public static readonly ICollection<River> Rivers;

        static Board()
        {
            var milepostMap = Mileposts
                                .Values
                                .ToDictionary(a => a.Id, a => a.Convert());

            Rivers = Connections
                                .Values
                                .Where(a => a.RiversCrossed != null)
                                .SelectMany(a => a.RiversCrossed)
                                .Distinct()
                                .Select(a => new River
                                {
                                    Name = a
                                })
                                .ToList();

            var connections = Connections
                                .Values
                                .Select(a => a.Import(milepostMap, Rivers))
                                .ToList();

            var ferries = Ferries
                                .Values
                                .Select(a => a.Import(milepostMap))
                                .ToList();

            BoardMileposts = milepostMap.Select(a => a.Value).ToList();
        }
    }
}
