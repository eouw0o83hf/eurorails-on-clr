using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core
{
    public abstract class Card
    {
        public readonly int CardId;

        protected Card(int cardId)
        {
            CardId = cardId;
        }
    }
}
