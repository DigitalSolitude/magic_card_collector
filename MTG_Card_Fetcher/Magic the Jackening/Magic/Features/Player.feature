Feature: Player

Background: I am a player
And I on a battlefield

Scenario: I have zones
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

Scenario: Return a card from the graveyard to hand
Given the card 'Shock' is in the graveyard
When I play a spell that returns that card to hand
Then that card is in my hand
And that card is not in my graveyard
And the number of cards in hand is increased by '1'
And the number of cards in the graveyard is decreased by '1'

Scenario: Play a card from exile
Given the card 'Shock' is in exile
And I can cast that card
When I cast that card
Then that card is on the battlefield
And that card is not in my exile zone

Scenario: Play a land card
Given I have a 'Land' card in hand
When I play that card
Then that card is not in my hand
And that card is on the battlefield
And that card is a 'Land' card

Scenario: Play a creature card
Given I have a 'Creature' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the battlefield
And that card is a 'Creature' card

Scenario: Return a creature card to the battlefield from the graveyard
Given I have a 'Creature' card in my graveyard
When I play a spell that returns that card to the battlefield
Then that card is not in my graveyard
And that card is on the battlefield
And that card is a 'Creature' card

Scenario: Play an instant card
Given I have an 'Instant' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the stack
And that card is a 'Instant' card

Scenario: Play a sorcery card
Given I have a 'Sorcery' card in my hand
When I play that card
Then that card is not in my hand
And that card is on the stack
And that card is a 'Sorcery' card

#Scenario: I can interact with the stack
#Given there is a spell on the stack
#When I play a spell that counters that spell
#Then I can counter that spell