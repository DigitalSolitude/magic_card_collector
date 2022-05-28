namespace Magic_the_Jackening
{
    public interface ICard
    {
        string Name { get; }
        List<EManaType> ManaValue { get; }
        ECardType CardType { get; }
        ESubType SubType { get; }
        string RulesText { get; }
        bool isTapped { get; }
    }
}