namespace Magic_the_Jackening
{
    internal class Library : IZone
    {
        public bool Visibility { get; set; }
        public static List<ICard>? cards = stack?.ToList();
        public static Stack<ICard>? stack { get; set; }

        public Library()
        {
            Visibility = true;
            stack = new Stack<ICard>();
        }
        
        public Stack<ICard> ListToStack(List<ICard> list)
        {
            return (Stack<ICard>)list.Cast<ICard>();
        }

        private ICard DrawFrom()
        {
            _ = stack.TryPop(out var card);
            if (card == null) throw new MagicExceptions.DrawFromEmptyLibrary();
            return card;
        }
    }
}