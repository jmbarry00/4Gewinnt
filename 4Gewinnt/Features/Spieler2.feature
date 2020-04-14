Feature: Spieler2

@mytag
Scenario: Spieler 2, choose color and set Spielstein
	Given It is Spieler 2 turn
	When he chooses the coloumn 4 on Spielfeld
	Then the Spielstein should land on row 1
	


