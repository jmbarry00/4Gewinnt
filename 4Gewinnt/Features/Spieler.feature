Feature: Spieler
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Spieler 1, choose color and set Spielstein
	Given It's Spieler 1 turn
	And he choose the color of his Spielstein
	When he chooses a coloumn on Spielfeld
	Then the Spielstein should land on the lowest field

Scenario: Spieler 2, choose color and set Spielstein
	Given It's Spieler 2 turn
	And he choose the color of his Spielstein
	When he chooses a coloumn on Spielfeld
	Then the Spielstein should land on the lowest field thats free
	


