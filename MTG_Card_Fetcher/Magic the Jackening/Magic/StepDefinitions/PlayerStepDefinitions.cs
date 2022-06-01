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
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            // Create forest and put it into play
            ICard basicForest = DummyCards.BasicForest;
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
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            // Create forest and put it into play
            ICard basicForest = DummyCards.BasicForest;
            // Taps the forest
            battlefield.Untap(battlefield.Cards[battlefield.Cards.IndexOf(basicForest)]);
            // Update the battlefield in the scenario context
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [Then(@"that card is untapped")]
        public void ThenThatCardIsUntapped()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
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
            Player player1 = battlefield.PlayerList.FirstOrDefault();
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
            Player player1 = battlefield.PlayerList.FirstOrDefault();
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
            // Ensure Player 1 has the passed card in hand
            battlefield.PlayerList.FirstOrDefault()._hand.Cards.Should().Contain(card);
        }

        [Then(@"I have '([^']*)' cards in my hand")]
        public void ThenIHaveCardsInMyHand(int count)
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            // Ensure Player 1 has the passed card in hand
            battlefield.PlayerList.FirstOrDefault()._hand.Cards.Count.Should().Be(count);
        }

        [Given(@"I check the top card of my library")]
        public void GivenICheckTheTopCardOfMyLibrary()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = battlefield.PlayerList.FirstOrDefault();
            ICard card = player1._library.Stack.Peek();
            _scenarioContext.Add(nameof(card), card);
        }

        [Then(@"that card is in my hand")]
        public void ThenThatCardIsInMyHand()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            ICard card = _scenarioContext.Get<ICard>(nameof(card));
            Player player1 = battlefield.PlayerList.FirstOrDefault();
            player1._hand.Cards.Should().Contain(card);
        }

        [When(@"I draw a card")]
        public void WhenIDrawACard()
        {
            // Retrieve Battlefield from the scenario context 
            Battlefield battlefield = _scenarioContext.Get<Battlefield>(nameof(battlefield));
            Player player1 = battlefield.PlayerList.FirstOrDefault();
            player1.DrawACard();
            _scenarioContext[nameof(battlefield)] = battlefield;
        }

        [When(@"I create a card with name '([^']*)'")]
        public void WhenICreateACardWithName(string name)
        {
            List<ICard> cards = new List<ICard>();
            CardImporter cardImporter = new CardImporter();
            cards = cardImporter.LoadCardsFromJson();
            var createdCard = cards.FindCardByName(name);
            _scenarioContext.Add(nameof(createdCard), createdCard);
        }

        [Then(@"I can create that card with name '([^']*)'")]
        public void ThenICanCreateThatCard(string name)
        {
            ICard createdCard = _scenarioContext.Get<ICard>(nameof(createdCard));
            Assert.AreEqual(createdCard.Name, name);
        }


        [Given(@"the card '([^']*)' is in hand")]
        public void GivenTheCardIsInHand(string shock)
        {
            throw new PendingStepException();
        }

        [When(@"I discard that card")]
        public void WhenIDiscardThatCard()
        {
            throw new PendingStepException();
        }

        [Then(@"that card is in my graveyard")]
        public void ThenThatCardIsInMyGraveyard()
        {
            throw new PendingStepException();
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
            throw new PendingStepException();
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


        [Given(@"I have an '([^']*)' card in my hand")]
        public void GivenIHaveAnCardInMyHand(string sorcery)
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
    }
}
