
namespace Magic_the_Jackening
{
    public interface ICard
    {
        string Name { get; }
        List<EManaType> ManaCost { get; }
        bool Castable { get; set; }
        ECardType CardType { get; }
        ESubType SubType { get; }
        string OracleText { get; }
        bool isTapped { get; set; }
    }
}