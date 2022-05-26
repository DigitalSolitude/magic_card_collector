using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening
{
    internal interface IZone
    {
        public List<EPlayer> Visibility { get; set; }
        public List<Card> Cards { get; set; }
        public EZone Name { get; }
    }
}
