namespace Magic_the_Jackening
{
    public interface ICard
    {
        EManaValue ManaValue;
        string Name;
        ECardtype CardType;
        ESubType SubType;
        string RulesText;

    }
}