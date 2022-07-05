using Magic_the_Jackening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Support
{
    [Binding]
    public class StepTransforms
    {
        [StepArgumentTransformation]
        public List<EManaType> ManaTypeListTransform(string manaType)
        {
            List<EManaType> manaTypes = new();
            foreach (char c in manaType)
            {
                EManaType mana = new ();
                if (c.ToString() == "R") mana = EManaType.Red;
                if (c.ToString() == "W") mana = EManaType.White;
                if (c.ToString() == "G") mana = EManaType.Green;
                if (c.ToString() == "B") mana = EManaType.Black;
                if (c.ToString() == "U") mana = EManaType.Blue;
                if (c.ToString() == "C") mana = EManaType.Colourless;
                Int32.TryParse(c.ToString(), out int genericManaNumber);
                for (int i = 0; i < genericManaNumber; i++)
                {
                    manaTypes.Add(EManaType.Generic);
                }
                manaTypes.Add(mana);
            }
            return manaTypes;
        }

        [StepArgumentTransformation]
        public ECardType CardTypeTransform(string cardType)
        {
            
            if (cardType == "Creature") return ECardType.Creature;
            if (cardType == "Land") return ECardType.Land;
            if (cardType == "Enchantment") return ECardType.Enchantment;
            if (cardType == "Instant") return ECardType.Instant;
            if (cardType == "Sorcery") return ECardType.Sorcery;
            if (cardType == "Artifact") return ECardType.Artifact;
            throw new ArgumentException($"Invalid Cardtype {cardType} is not supported.");
        }

        [StepArgumentTransformation]
        public ESubType SubTypeTransform(string subType)
        {

            if (subType == "None") return null;
            throw new ArgumentException($"Invalid subType {subType} is not supported.");
        }

        public EZone ZoneTypeTransform(string zone)
        {
            zone = zone.ToLower();
            if (zone == "exile") return EZone.Exile;
            if (zone == "library") return EZone.Library;
            if (zone == "hand") return EZone.Hand;
            if (zone == "graveyard") return EZone.Graveyard;
            if (zone == "battlefield") return EZone.Battlefield;
            throw new ArgumentException($"Invalid Zone {zone} is not supported.");
        }
    }
}
