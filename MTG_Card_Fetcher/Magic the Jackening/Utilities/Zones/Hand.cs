namespace Magic_the_Jackening.Zones
{
    public class Hand : IZone
    {
        public bool Visibility { get; set; }
        public List<ICard> Cards { get; set; }

        public Hand()
        {
            Visibility = true;
            Cards = new List<ICard>();
        }

        public ICard Discard(ICard card)
        {
            Cards.Remove(card);
            return card;
        }
    }
}