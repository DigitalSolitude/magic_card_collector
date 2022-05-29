namespace Magic_the_Jackening
{
    public class Card : ICard
    {
        public string Name { get; }
        public List<EManaType> ManaCost { get; }
        public ECardType CardType { get; }
        public ESubType SubType { get; }
        public string OracleText { get; }
        public bool isTapped { get; set; }
        public Card(string name, List<EManaType> manaValue, ECardType cardType, string oracleText , ESubType subtype = null)
        {
            Name = name;
            ManaCost = manaValue;
            CardType = cardType;
            OracleText = oracleText;
            SubType = subtype;
        }
    }
}