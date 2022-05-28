namespace Magic_the_Jackening
{
    internal class Hand : IZone
    {
        public bool Visibility { get; set; }
        public List <ICard> Cards { get; set; }

        public Hand()
        {
            Visibility = true;
            Cards = new List<ICard>();
        }
    }

    internal class Library : IZone
    {
        public bool Visibility { get; set; }
        public static List<ICard>? Cards = Stack?.ToList();
        public static Stack<ICard>? Stack { get; set; }

        public Library()
        {
            Visibility = true;
            Stack = new Stack<ICard>();
        }
        
        public Stack<ICard> ListToStack(List<ICard> list)
        {
            return (Stack<ICard>)list.Cast<ICard>();
        }

    }
}