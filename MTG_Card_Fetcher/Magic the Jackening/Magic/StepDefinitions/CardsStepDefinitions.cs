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

        [Given(@"I find a card called '([^']*)'")]
        public void GivenIFindACardCalledShock(string name)
        {
            ICard shock = new Card(
                name: "Shock",
                manaValue: new List<EManaType> { EManaType.Red },
                cardType: ECardType.Instant,
                oracleText: "Deal 2 damage to any target"
                );
            _scenarioContext.Add(nameof(shock), shock);

            ICreature shivanDragon = new Utilities.Creature(
                name: "Shivan Dragon",
                power: 5,
                toughness: 5,
                manaValue: new List<EManaType> { EManaType.Red, EManaType.Red, EManaType.Generic, EManaType.Generic, EManaType.Generic, EManaType.Generic },
                cardType: ECardType.Creature,
                oracleText: "R: {this card} gets +1/+0 until end of turn",
                keywords: new List<EKeyWords> { EKeyWords.Flying }
                );
            _scenarioContext.Add(nameof(shivanDragon), shivanDragon);

        }

        [Then(@"it is named '([^']*)', Mana Cost is '([^']*)', it has rule text '([^']*)', it has card type '([^']*)' and subtype '([^']*)'")]
        public void ThenItIsNamedManaCostIsItHasRuleTextItHasCardTypeAndSubtype(string name, List<EManaType> manaValue, string rulesText, ECardType cardType, ESubType subtype = null)
        {
            ICard shivanDragon = _scenarioContext.Get<ICard>(nameof(shivanDragon));
            ICard shock = _scenarioContext.Get<ICard>(nameof(shock));

            if (name == shivanDragon.Name)
            {
                shivanDragon.Should().BeEquivalentTo(new Card(name, manaValue, cardType, rulesText));
            }

            if (name == shock.Name)
            {
                shock.Should().BeEquivalentTo(new Card(name, manaValue, cardType, rulesText));
            }

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
