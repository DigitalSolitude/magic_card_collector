using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Magic_the_Jackening
{
    [Binding]
    public class CardsStepDefinitions
    {
        public readonly ScenarioContext _scenarioContext;
        public CardsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I find a card called Shock")]
        public void GivenIFindACardCalledShock()
        {
            ICard shock = new Card(
                name: "Shock",
                manaValue: new List<EManaType> { EManaType.Red },
                cardType: ECardType.Instant,
                oracleText: "Deal 2 damage to any target"
                );
            _scenarioContext.Add(nameof(shock), shock);
        }

        [Then(@"it is named '([^']*)', Mana Cost is '([^']*)', it has rule text '([^']*)', it has card type '([^']*)' and subtype '([^']*)'")]
        public void ThenItIsNamedManaCostIsItHasRuleTextItHasCardTypeAndSubtype(string name, List<EManaType> manaValue, string rulesText, ECardType cardType, ESubType subtype = null)
        {
            ICard shock = _scenarioContext.Get<ICard>(nameof(shock));
            shock.Should().BeEquivalentTo(new Card(name, manaValue, cardType, rulesText));
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
            throw new PendingStepException();
        }

        [Then(@"I exile '([^']*)' number of cards")]
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


    }
}


