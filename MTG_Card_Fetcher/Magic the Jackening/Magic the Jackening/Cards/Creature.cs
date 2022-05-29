using Magic_the_Jackening;

namespace Utilities
{
    public class Creature : ICreature
    {
        public string Name { get; }
        public int Power { get; }
        public int Toughness { get; }
        public List<EKeyWords> KeyWords { get; }
        public List<EManaType> ManaCost { get; }
        public ECardType CardType { get; }
        public ESubType SubType { get; }
        public string OracleText { get; }
        public bool isTapped { get; set; }

        public Creature(string name, int power, int toughness, List<EKeyWords> keywords, List<EManaType> manaValue, ECardType cardType, string oracleText, ESubType subType = null)
        {
            Name = name;
            Power = power;
            Toughness = toughness;
            KeyWords = keywords;
            ManaCost = manaValue;
            CardType = cardType;
            OracleText = oracleText;
            SubType = subType;
        }
    }
}