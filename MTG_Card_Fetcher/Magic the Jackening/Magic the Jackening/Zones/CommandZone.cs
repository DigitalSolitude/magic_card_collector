using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening.Zones
{
    internal class CommandZone : IZone
    {
        public bool Visibility { get; set; }
        public List<ICard>? cards { get; set; }
        public int timesCommanderCast { get; set; }
    }
}
