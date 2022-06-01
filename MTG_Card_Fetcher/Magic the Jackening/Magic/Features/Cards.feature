Feature: Cards

Game

@JamesyGoringBaby
Scenario: Card has a name, mana cost, attributes and rules
Given I have given a name
When I press add
Then the result should be the name on screen.

Scenario Outline: Check Card Properties
Given I find a card called '<Name>'
Then it is named '<Name>', Mana Cost is '<Mana Cost>', it has rule text '<Rules Text>', it has card type '<Card Type>' and subtype '<Subtype>'
Examples:
  | Name          | Mana Cost | Rules Text                                  | Card Type | Subtype |
  | Shock         | R         | Deal 2 damage to any target                 | Instant   | None    |
  | Shivan Dragon | 4RR       | R: {this card} gets +1/+0 until end of turn | Creature  | None    |

Scenario: Draw Card
Given I have 3 cards in hand
And I have 50 cards in my library
When I draw a card
Then I have 4 cards in hand 
And 49 cards in my library

Scenario Outline: I can load cards from a JSON
When I create a card with name '<Name>'
Then I can create that card with name '<Name>'
Examples: 
| Name           |
| Shock          |
| Counterspell   |
| Llanowar Elves |






