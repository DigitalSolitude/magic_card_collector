using Magic_the_Jackening;

namespace Utilities
{
    public class Land : ILand
    {
        public string Name { get; }
        public List<EManaType> ManaCost => new List<EManaType>();
        public List<ELandType> ElandTypes { get; }
        public bool Playable { get; set; }
        public ECardType CardType { get; }
        public string OracleText { get; }
        public bool isTapped { get; set; }
        public ESubType SubType { get; }

        public Land(string name, List<ELandType> landTypes, ECardType cardType, string oracleText)
        {
            Name = name;
            ElandTypes = landTypes;
            CardType = cardType;
            OracleText = oracleText;
        }

    }
}