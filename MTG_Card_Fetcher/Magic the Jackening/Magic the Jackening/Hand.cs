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
}