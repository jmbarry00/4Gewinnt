Feature: Spieler

@mytag
Scenario: Spieler 1, choose color and set Spielstein
	When I create a Spieler
	Then It's Spieler 1 turn
	And The color is on blau

Scenario: switchPlayer
	Given It Spieler 1 turn
	When I switch the player
	Then It should be Player 2 turn
	


