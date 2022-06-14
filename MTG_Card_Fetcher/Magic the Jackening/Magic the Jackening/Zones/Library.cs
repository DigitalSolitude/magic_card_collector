namespace Magic_the_Jackening.Zones
{
    public class Library : IZone
    {
        public bool Visibility { get; set; }
        public List<ICard>? Cards = new();
        public Stack<ICard>? Stack { get; set; }

        public Library()
        {
            Visibility = true;
            Stack = new Stack<ICard>();
            Cards = Stack?.ToList();
        }

        public Stack<ICard> ListToStack(List<ICard> list)
        {
            return (Stack<ICard>)list.Cast<ICard>();
        }

        public ICard TakeTopCard()
        {
            _ = Stack.TryPop(out var card);
            if (card == null) throw new MagicExceptions.DrawFromEmptyLibrary();
            return card;
        }

        public ICard PlayCard(ICard card)
        {
            return Cards[Cards.IndexOf(card)];
        }
    }
}