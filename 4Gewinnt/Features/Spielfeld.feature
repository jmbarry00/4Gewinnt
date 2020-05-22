Feature: Spielfeld
	Ein Spielfeld mit Y Zeilenund X Spalten

@mytag
Scenario: game start
	When I create a Spielfeld with 7 columns and 6 rows,
	Then Spielfeld has 7 columns and 6 rows
