﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_the_Jackening.Zones
{
    public class CommandZone : IZone
    {
        public bool Visibility { get; set; }
        public List<ICard>? Cards { get; set; }
        public int timesCommanderCast { get; set; }
        public ICard PlayCard(ICard card)
        {
            return Cards[Cards.IndexOf(card)];
        }
    }
}
