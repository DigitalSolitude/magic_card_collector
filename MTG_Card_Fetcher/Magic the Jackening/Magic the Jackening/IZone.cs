using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening
{
    internal interface IZone
    {
        public bool Visibility { get; set; }
        public List<ICard> Cards { get; set; }
    }

    internal interface ICreature : ICard
    {
        ICard
    }

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