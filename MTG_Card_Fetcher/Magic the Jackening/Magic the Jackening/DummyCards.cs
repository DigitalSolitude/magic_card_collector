using Magic_the_Jackening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class DummyCards
    {
        public static ICard Shock = new Card(
                name: "Shock",
                manaValue: new List<EManaType> { EManaType.Red },
                cardType: ECardType.Instant,
                oracleText: "Deal 2 damage to any target"
                );
        public static ICreature ShivanDragon = new Creature(
                name: "Shivan Dragon",
                power: 5,
                toughness: 5,
                manaValue: new List<EManaType> { EManaType.Red, EManaType.Red, EManaType.Generic, EManaType.Generic, EManaType.Generic },
                cardType: ECardType.Creature,
                oracleText: "R: {this card} gets +1/+0 until end of turn",
                keywords: new List<EKeyWords> { EKeyWords.Flying }
                );
        public static ILand BasicForest = new Land(
            name: "Forest",
            landTypes: new List<ELandType> { ELandType.Forest, ELandType.Basic },
            cardType: ECardType.Land,
            oracleText: "{T} Add {G}"
            );
    }

    public enum ELandType
    {
        Basic,
        Forest,
        Island,
        Plains,
        Swamp,
        Mountain
    }
}
