Feature: GewinnBerechnung
		Wenn senkrecht, waagrecht oder diagonal in beide Richtungen 
		vier Steine eines Spielers nebeneinander liegen, hat derjenige Spieler gewonnen.

@mytag
Scenario: Spieler 1 hat gewonnen, wenn vier Steine waagrecht nebeneinander liegen
	Given three waagrecht
	When player one sets the fourth
	Then player one wins

Scenario: Spieler 2 hat gewonnen, wenn vier Steine senkrecht nebeneinander liegen
	Given three senkrecht
	When player two sets the fourth
	Then player two wins

Scenario: Spieler 1 hat gewonnen, wenn vier vorwärts diagonal nebeneinander liegen
	Given It's Spieler1 turn
	When 4 Spielsteine of Spieler 1 are side by side
	Then Spieler one wins the game

Scenario: Spieler 2 hat gewonnen, wenn vier Steine rückwärts diagonal nebeneinander liegen
	Given three diagonal backwards
	When player two sets the fourth Spielstein
	Then player two wins the game

Scenario: Unentschieden
	Given All fields are occupied except one
	When next Player sets Spielstein without winning

