namespace Magic_the_Jackening
{
    internal class Hand : IZone
    {
        public bool Visibility { get; set; }
        public List <ICard> cards { get; set; }

        public Hand()
        {
            Visibility = true;
            cards = new List<ICard>();
        }
    }
}