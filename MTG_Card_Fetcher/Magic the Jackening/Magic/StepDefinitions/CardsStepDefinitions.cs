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
                rulesText: "Deal 2 damage to any target"
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

        [When(@"I draw a card")]
        public void WhenIDrawACard()
        {
            throw new PendingStepException();
        }

        [Then(@"I have (.*) cards in hand")]
        public void ThenIHaveCardsInHand(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"(.*) cards in my library")]
        public void ThenCardsInMyLibrary(int p0)
        {
            throw new PendingStepException();
        }
    }
}
