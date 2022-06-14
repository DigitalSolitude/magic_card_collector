using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening.Zones
{
    public class Exile : IZone
    {
        public bool Visibility { get; set; }
        public List<ICard>? Cards { get; set; }

        public Exile()
        {
            Visibility = true;
            Cards = new List<ICard>();
        }

        public ICard PlayCard(ICard cardName)
        {
            ICard card = Cards[Cards.IndexOf(cardName)];
            Cards.Remove(card);
            return card;
        }
    }

}
