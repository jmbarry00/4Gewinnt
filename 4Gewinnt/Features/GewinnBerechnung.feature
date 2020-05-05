Feature: GewinnBerechnung

@mytag
Scenario: Spieler 1 hat gewonnen, wenn vier blaue Steine waagrecht, senkrecht oder diagonal nebeneinander liegen
	Given It's Spieler1 turn
	When 4 Spielsteine of Spieler 1 are side by side
	Then Spieler 1 hat gewonnen

