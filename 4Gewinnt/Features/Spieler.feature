Feature: Spieler

@mytag
Scenario: Spieler 1, choose color and set Spielstein
	Given It's Spieler 1 turn
	//And he choose the color of his Spielstein
	When he chooses coloumn 4 on Spielfeld
	Then the Spielstein should land on the lowest field
	


