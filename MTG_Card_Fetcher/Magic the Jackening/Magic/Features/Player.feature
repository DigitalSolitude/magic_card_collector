Feature: Player

Game

Scenario: I have zones
Given I am a player
Then I have a hand, library, graveyard, exile zone

Scenario Outline: I can add any mana to my mana pool
Given I have no mana in my mana pool
When I add '<Number>' '<Mana Type>' mana to my mana pool
Then I have that mana in my mana pool
Examples: 
| Number | Mana Type  |
| 1      | Red        |
| 5      | Green      |
| 2      | Blue       |
| 3      | White      |
| 7      | Black      |
| 3      | Colourless |
| 6      | Generic    |

Scenario: Untap my cards
Given I have a tapped card
When I untap that card
Then that card is untapped

Scenario: Draw a card
Given I have '1' card in my hand
When I draw a card
Then I have '2' cards in my hand

Scenario: Draw from my library
Given I check the top card of my library
When I draw a card
Then that card is in my hand

Scenario: Discard a card
Given the card 'Shock' is in hand
When I discard that card
Then that card is in my graveyard 

Scenario: Play a land card
Given I have a 'Land' card in hand
When I play that card
Then that card is not in my hand
And that card is on the battlefield
And I am the owner of that card
And I am the controller of that card
And that card is a 'Land' card

Scenario: Play a creature card
Given I have a 'Creature' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the battlefield
And I am the owner of that card
And I am the controller of that card
And that card is a 'Creature' card

Scenario: Play an instant card
Given I have an 'Instant' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the stack
And I am the owner of that card
And I am the controller of that card
And that card is a 'Instant' card

Scenario: Play a sorcery card
Given I have an 'Sorcery' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the stack
And I am the owner of that card
And I am the controller of that card
And that card is a 'Sorcery' card

Scenario: I can interact with the stack
Given there is a spell on the stack
When I play a spell that counters that spell
Then I can counter that spell