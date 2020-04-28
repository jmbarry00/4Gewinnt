Feature: Spielfeld
	Ein Spielfeld mit X Spalten und Y Zeilen

@mytag
Scenario: game start
	When I create a Spielfeld with 7 columns and 6 rows,
	Then Spielfeld has 7 columns and 6 rows
