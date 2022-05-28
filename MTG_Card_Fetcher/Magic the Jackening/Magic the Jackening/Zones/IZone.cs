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
        public static List<ICard>? cards { get; set; }
    }
}