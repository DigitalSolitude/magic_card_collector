using FluentAssertions.Execution;
using Magic_the_Jackening;
using System;
using TechTalk.SpecFlow;
using Utilities;

namespace MagicTests.StepDefinitions
{
    [Binding]
    public class PlayerStepDefinitions
    {
        public readonly ScenarioContext _scenarioContext;
        public PlayerStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am a player")]
        [Given(@"I on a battlefield")]
        public void GivenIOnABattlefield()
        {
            // Create a battlefield
            Battlefield battlefield = new Battlefield();
            // Create a player
            Player player1 = new Player("Jack");
            // Add that player to the battlefield
            player1._library.Stack.Push(DummyCards.BasicForest);
            battlefield.AddPlayer(player1);
            // Store the player in the Scenario Context for future use
            _scenarioContext.Add(nameof(player1), player1);
            // Store the battlefield in the Scenario Context for future use
            _scenarioContext.Add(nameof(battlefield), battlefield);
        }

        [Then(@"I have a hand, library, graveyard, exile zone")]
        public void ThenIHaveAHandLibraryGraveyardExileZone()
        {
            // Retrieve Player 1 from the scenario context
            Player player1 = _scenarioContext.Get<Player>(nameof(player1));
            // Ensure Player 1 has a hand, a graveyard, a library and an exile zone
            using (new AssertionScope())
            {
                player1._hand.Should().NotBeNull();
                player1._library.Should().NotBeNull();
                player1._graveyard.Should().NotBeNull();
                player1._exile.Should().NotBeNull();
            }
        }

        [Given(@"I have no mana in my mana pool")]
        public void GivenIHaveNoManaInMyManaPool()
        {
            // Retrieve Player 1 from the scenario context 
            Player player1 = _scenarioContext.Get<Player>(nameof(player1));
            // Empty their mana pool
            player1.ManaPool = new();
            // Overwrite the Player 1 object in the Scenario Context
            _scenarioContext[nameof(player1)] = player1;
        }

        [When(@"I add '([^']*)' '([^']*)' mana to my mana pool")]
        public void WhenIAddManaToMyManaPool(int number, EManaType manaType)
        {
            // Retrieve Player 1 from the scenario context 
            Player player1 = _scenarioContext.Get<Player>(nameof(player1));

            // Foreach mana passed, add it to player 1s mana pool
            for (int i=0; i < number; i++) player1.ManaPool.Add(manaType);
            // Overwrite the Player 1 object in the Scenario Context
            _scenarioContext[nameof(player1)] = player1;

            //Foreach mana passed, add it to a control mana list
            List<EManaType> manaPool = new List<EManaType>();
            for (int i = 0; i < number; i++) manaPool.Add(manaType);

            // Store the control mana list in the scenario context for future use
            _scenarioContext.Add(nameof(manaPool), manaPool);
        }

        [Then(@"I have that mana in my mana pool")]
        public void ThenIHaveThatManaInMyManaPool()
        {
            // Retrieve Player 1 from the scenario context 
            Player player1 = _scenarioContext.Get<Player>(nameof(player1));

            // Retrieve control mana list from Scenario Context
            List<EManaType> manaPool = _scenarioContext.Get<List<EManaType>>(nameof(manaPool));

            // Ensure player 1s mana pool is the same as the control mana pool
            player1.ManaPool.Should().BeEquivalentTo(manaPool);
        }

        [Given(@"I have a tapped card")]
        public void GivenIHaveATappedCard()
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();
            // Create forest and put it into play
            ICard basicForest = DummyCards.BasicForest;
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            battlefield.Cards.Add(basicForest);
            // Tap the forest
            battlefield.Tap(basicForest);
            // Update the battlefield in the scenario context
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [When(@"I untap that card")]
        public void WhenIUntapThatCard()
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();
            // Create forest and put it into play
            ICard basicForest = DummyCards.BasicForest;
            // Taps the forest
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            battlefield.Untap(battlefield.Cards[battlefield.Cards.IndexOf(basicForest)]);
            // Update the battlefield in the scenario context
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Then(@"that card is untapped")]
        public void ThenThatCardIsUntapped()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();
            // Create forest to find it on the battlefield
            ICard basicForest = DummyCards.BasicForest;
            ICard card = battlefield.Cards[battlefield.Cards.IndexOf(basicForest)];
            // Ensure the forest is tapped
            card.isTapped.Should().BeFalse( "The card has been untapped");
        }

        [Given(@"I have card '([^']*)' in my hand")]
        public void GivenIHaveCardInMyHand(ICard card)
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();

            // Add passed card to Player 1s hand
            player1._hand.Cards.Add(card);
            // Update the battlefield in the scenario context
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Given(@"I have '([^']*)' card in my hand")]
        public void GivenIHaveCardInMyHand(int count)
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();

            // Add passed card to Player 1s hand
            player1._hand.Cards.Add(DummyCards.Shock);
            // Update the battlefield in the scenario context
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Then(@"I have '([^']*)' card in my hand")]
        public void ThenIHaveCardsInMyHand(ICard card)
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();
            // Ensure Player 1 has the passed card in hand
            battlefield.PlayerList.FirstOrDefault()._hand.Cards.Should().Contain(card);
        }

        [Then(@"I have '([^']*)' cards in my hand")]
        public void ThenIHaveCardsInMyHand(int count)
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();
            // Ensure Player 1 has the passed card in hand
            battlefield.PlayerList.FirstOrDefault()._hand.Cards.Count.Should().Be(count);
        }

        [Given(@"I check the top card of my library")]
        public void GivenICheckTheTopCardOfMyLibrary()
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();

            ICard card = player1._library.Stack.Peek();
            _scenarioContext.Add(nameof(card), card);
        }

        [Then(@"that card is in my hand")]
        public void ThenThatCardIsInMyHand()
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();
            ICard card = _scenarioContext.Get<ICard>(nameof(card));

            player1._hand.Cards.Should().Contain(card);
        }

        [When(@"I draw a card")]
        public void WhenIDrawACard()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();

            player1.DrawACard();
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Given(@"the card '([^']*)' is in hand")]
        public void GivenTheCardIsInHand(string cardName)
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();

            player1._hand.Cards.Add(DummyCards.Shock);
        }

        [When(@"I discard that card")]
        public void WhenIDiscardThatCard()
        {
            // Retrieve Battlefield from the scenario context 
            Player player1 = GetPlayer1();
            player1.DiscardACard(DummyCards.Shock);
        }

        private Player GetPlayer1()
        {
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            return battlefield.PlayerList.FirstOrDefault();
            
        }

        private ICard CreateCard(string cardName) =>
            cardName.ToLower() switch
            {
                "shock" => DummyCards.Shock,
                "shivan dragon" => DummyCards.ShivanDragon,
                "basic forest" => DummyCards.BasicForest,
                _ => throw new ArgumentException($"Unknown card {cardName}")
            };



        [Then(@"that card is in my graveyard")]
        public void ThenThatCardIsInMyGraveyard()
        {
            Player player1 = GetPlayer1();
            player1._graveyard.Cards.Should().Contain(CreateCard("shock"));
        }

        [Given(@"I have a '([^']*)' card in hand")]
        public void GivenIHaveACardInHand(string land)
        {
            throw new PendingStepException();
        }

        [When(@"I play that card")]
        public void WhenIPlayThatCard()
        {
            throw new PendingStepException();
        }

        [Then(@"that card is not in my hand")]
        public void ThenThatCardIsNotInMyHand()
        {
            throw new PendingStepException();
        }

        [Then(@"that card is on the battlefield")]
        public void ThenThatCardIsOnTheBattlefield()
        {
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            battlefield.Cards.Should().Contain(CreateCard("shock"));
        }

        [Then(@"I am the owner of that card")]
        public void ThenIAmTheOwnerOfThatCard()
        {
            throw new PendingStepException();
        }

        [Then(@"I am the controller of that card")]
        public void ThenIAmTheControllerOfThatCard()
        {
            throw new PendingStepException();
        }

        [Then(@"that card is a '([^']*)' card")]
        public void ThenThatCardIsACard(string land)
        {
            throw new PendingStepException();
        }

        [Given(@"I have an '([^']*)' card in my hand")]
        [Given(@"I have a '([^']*)' card in my hand")]
        public void GivenIHaveACardInMyHand(string creature)
        {
            throw new PendingStepException();
        }

        [Then(@"that card is on the stack")]
        public void ThenThatCardIsOnTheStack()
        {
            throw new PendingStepException();
        }

        [Given(@"there is a spell on the stack")]
        public void GivenThereIsASpellOnTheStack()
        {
            throw new PendingStepException();
        }

        [When(@"I play a spell that counters that spell")]
        public void WhenIPlayASpellThatCountersThatSpell()
        {
            throw new PendingStepException();
        }

        [Then(@"I can counter that spell")]
        public void ThenICanCounterThatSpell()
        {
            throw new PendingStepException();
        }

        [Given(@"I have (.*) cards in hand")]
        public void GivenIHaveCardsInHand(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have (.*) cards in my library")]
        public void GivenIHaveCardsInMyLibrary(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the card '([^']*)' is in the graveyard")]
        public void GivenTheCardIsInTheGraveyard(string shock)
        {
            throw new PendingStepException();
        }

        [When(@"I play a spell that returns that card to hand")]
        public void WhenIPlayASpellThatReturnsThatCardToHand()
        {
            throw new PendingStepException();
        }

        [Then(@"the number of cards in hand is increased by '([^']*)'")]
        public void ThenTheNumberOfCardsInHandIsIncreasedBy(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the number of cards in the graveyard is decreased by '([^']*)'")]
        public void ThenTheNumberOfCardsInTheGraveyardIsDecreasedBy(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have a card in my hand that allowed me to play from exile")]
        public void GivenIHaveACardInMyHandThatAllowedMeToPlayFromExile()
        {
            var card = CreateCard("shock");
        }

        [Then(@"I exile '([^']*)' number of cards from my hand")]
        public void ThenIExileNumberOfCards(string x)
        {
            throw new PendingStepException();
        }

        [Then(@"I can play those card\(s\)")]
        public void ThenICanPlayThoseCardS()
        {
            throw new PendingStepException();
        }

        [Then(@"I am the owner of those card\(s\)")]
        public void ThenIAmTheOwnerOfThoseCardS()
        {
            throw new PendingStepException();
        }

        [Then(@"I am the controller of those card\(s\)")]
        public void ThenIAmTheControllerOfThoseCardS()
        {
            throw new PendingStepException();
        }

        [Then(@"those card\(s\) are '([^']*)' card")]
        public void ThenThoseCardSAreCard(string type)
        {
            throw new PendingStepException();
        }

        [Then(@"those card\(s\) are removed from exile after playing them")]
        public void ThenThoseCardSAreRemovedFromExileAfterPlayingThem()
        {
            throw new PendingStepException();
        }

        [Given(@"I have a '([^']*)' card in my graveyard")]
        public void GivenIHaveACardInMyGraveyard(string creature)
        {
            throw new PendingStepException();
        }

        [When(@"I play a spell that returns that card to the battlefield")]
        public void WhenIPlayASpellThatReturnsThatCardToTheBattlefield()
        {
            throw new PendingStepException();
        }

        [Then(@"that card is not in my graveyard")]
        public void ThenThatCardIsNotInMyGraveyard()
        {
            throw new PendingStepException();
        }

        [Given(@"the card '([^']*)' is in exile")]
        public void GivenTheCardIsInExile(string cardName)
        {
            var player1 = GetPlayer1();
            player1._exile.Cards.Add(CreateCard(cardName));
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            _scenarioContext[nameof(player1)] = player1;
        }

        [Given(@"I can cast that card")]
        public void GivenICanCastThatCard()
        {
            var player1 = GetPlayer1();
            foreach (var card in player1._exile.Cards)
            {
                if (card.Name.ToLower() == "shock") card.Playable = true;
            }
            _scenarioContext[nameof(player1)] = player1;
        }

        [When(@"I cast that card")]
        public void WhenICastThatCard()
        {
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            var player1 = GetPlayer1();
            var shock = DummyCards.Shock;
            battlefield.Cards.Add(battlefield.PlayerList[battlefield.PlayerList.IndexOf(player1)]._exile.PlayCard(shock));
            battlefield.PlayerList[battlefield.PlayerList.IndexOf(player1)] = player1;
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Then(@"that card is not in my exile zone")]
        public void ThenThatCardIsNotInMyExileZone()
        {
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = GetPlayer1();
            player1 = battlefield.PlayerList[battlefield.PlayerList.IndexOf(player1)];
            player1._exile.Cards.Should().NotContain(CreateCard("shock"));
        }

    }
}
