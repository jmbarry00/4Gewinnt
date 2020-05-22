Feature: Spieler

@mytag
Scenario: Spieler 1, set color and set Spielstein
	When I create a Spieler
	Then It's Spieler 1 turn
	When Spieler 1 chooses the coloumn 4 on Spielfeld
	Then Spielstein should land on row 0


Scenario: switchPlayer
	Given Spieler 1 turn
	When I switch the player
	Then It should be Player 2 turn




	


