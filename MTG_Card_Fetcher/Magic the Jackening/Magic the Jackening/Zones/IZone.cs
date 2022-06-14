using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening
{
    public interface IZone
    {
        public bool Visibility { get; set; }
        public static List<ICard>? Cards { get; set; }
        public ICard PlayCard(ICard card);
}
}