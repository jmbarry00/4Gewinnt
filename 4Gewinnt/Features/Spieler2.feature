Feature: Spieler2

@mytag
Scenario: Spieler 2, choose color and set Spielstein
	Given It is Spieler 2 turn
	//And he choose the color of his Spielstein
	When he chooses the coloumn 4 on Spielfeld
	Then the Spielstein should land on row 1
	


