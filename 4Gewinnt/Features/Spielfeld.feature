Feature: Spielfeld
	Ein Spielfeld mit X Spalten und Y Zeilen

@mytag
Scenario: game start
	When I create a Spielfeld with 6 columns and 5 rows,
	Then Spielfeld has 6 columns and 5 rows
