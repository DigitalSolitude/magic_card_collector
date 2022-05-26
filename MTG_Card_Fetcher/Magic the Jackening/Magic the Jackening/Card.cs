namespace Magic_the_Jackening
{
    public class Card : ICard
    {
        public string Name { get; }

        public List<EManaType> ManaValue { get; }

        public ECardType CardType { get; }

        public ESubType SubType { get; }

        public string RulesText { get; }

        public Card(string name, List<EManaType> manaValue, ECardType cardType, string rulesText , ESubType subtype = null)
        {
            Name = name;
            ManaValue = manaValue;
            CardType = cardType;
            RulesText = rulesText;
            SubType = subtype;
        }
    }
}