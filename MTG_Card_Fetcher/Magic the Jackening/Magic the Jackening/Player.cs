﻿using Magic_the_Jackening;
using Magic_the_Jackening.Zones;

namespace MagicTests.StepDefinitions
{
    public class Player
    {
        public string _name;
        public List<IZone> _zones = new();
        public Library _library;
        public Hand _hand;
        public Exile _exile;
        public Graveyard _graveyard;
        public CommandZone _commandZone;
        public int life;
        public List<EManaType> ManaPool;

        public Player(string name)
        {
            _name = name;
            _library = new Library();
            _hand = new Hand();
            _exile = new Exile();
            _graveyard = new Graveyard();
            _commandZone = new CommandZone();
            _zones.Add(_library);
            _zones.Add(_hand);
            _zones.Add(_exile);
            _zones.Add(_graveyard);
            _zones.Add(_commandZone);

            life = 40;
        }

        public int cardsInHand => _hand.Cards.Count;
        public int cardsInLibrary => _library.Cards.Count;
        public int cardsInGraveyard => _graveyard.Cards.Count;
        public int cardsInExile => _exile.Cards.Count;
        public void DrawACard() => _hand.Cards.Add(_library.TakeTopCard());
        public void DiscardACard(ICard card) => _graveyard.Cards.Add(_hand.Discard(card));

        public void AddMana(EManaType manaType)
        {
            ManaPool.Add(manaType);
        }
    }
}