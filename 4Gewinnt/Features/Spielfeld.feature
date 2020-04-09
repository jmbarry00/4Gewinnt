Feature: Spielfeld
	Ein Spielfeld mit X Spalten und Y Zeilen

@mytag
Scenario: game start
	When I create a Spielfeld with 6 columns and 5 rows,
	Then Spielfeld has 6 columns and 5 rows
	And Spieler gets created

Scenario: 4 in a row
	Given 3 in a row of Spieler 2
	And Its Spieler 2 turn
	When he chooses the right coloumn to make it 4 in a row,
	Then Spieler 2 won