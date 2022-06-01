using Magic_the_Jackening;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class CardImporter
    {
        public List<ICard> LoadCardsFromJson()
        {
            List<ICard> cards = new List<ICard>();

            using (StreamReader reader = new StreamReader("oracle-cards.json"))
            {
                string json = reader.ReadToEnd();
                var cards1 = JsonConvert.DeserializeObject<ICard>(json);
            }
            return ConvertCards(cards);
        }

        private List<ICard> ConvertCards(List<ICard> cards)
        {
            List<ICard> trimmedCards = new List<ICard>();
            foreach (Card card in cards)
            {
                trimmedCards.Add(new Card(
                    name: card.Name,
                    cardType: card.CardType,
                    manaValue: card.ManaCost,
                    oracleText: card.OracleText,
                    subtype: card.SubType
                    ));
            }
            return trimmedCards;
        }
    }
}
