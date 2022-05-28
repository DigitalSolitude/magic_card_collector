namespace Magic_the_Jackening
{
    internal interface ICreature : ICard
    {
        public int Power { get; }
        public int Toughness { get; }
        public List<EKeyWords> keyWords { get; }
    }
}