using Magic_the_Jackening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Extensions
    {
        public static ICard FindCardByName(this List<ICard> cards, string name)
        {
            var card = cards.FirstOrDefault(x => x.Name == name);
            if (card == null)
            {
                throw new ArgumentException($"Card {name} is not a card");
            }
            return card;
        }
    }
}
