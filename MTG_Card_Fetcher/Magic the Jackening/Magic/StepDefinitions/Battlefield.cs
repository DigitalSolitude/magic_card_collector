using Magic_the_Jackening;
using System.Linq;

namespace MagicTests.StepDefinitions
{
    // Something of a master class for now
    internal class Battlefield
    {
        public List<Player>? PlayerList;
        public List<ICard>? Cards;
        public List<IZone> Zones;

        public Battlefield()
        {
            PlayerList = new List<Player>();
            Cards = new List<ICard>(); 
            Zones = GetZones();
        }

        private List<IZone> GetZones()
        {
            List<IZone> zones = new List<IZone>();
            foreach (var player in PlayerList)
            {
                foreach (IZone zone in player._zones)
                {
                    zones.Add(zone);
                }
            }
            return zones;
        }

        internal void AddPlayer(Player player)
        {
            PlayerList.Add(player);
            Zones = GetZones();
        }

        internal void RemovePlayer(Player player)
        {
            PlayerList.Remove(player);
            Zones = GetZones();
        }

        internal void Tap(ICard card)
        {
            card.isTapped = true;
        }

        internal void Untap(ICard card)
        {
            card.isTapped = false;
        }
    }
}