namespace Magic_the_Jackening
{
    public interface ICreature : ICard
    {
        public int Power { get; }
        public int Toughness { get; }
        public List<EKeyWords> KeyWords { get; }
    }
}