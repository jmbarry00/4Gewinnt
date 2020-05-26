Feature: OutOfBounds

@mytag
Scenario: Player chooses full column
	Given Column 3 is all occupied
	When player 2 chooses column 3
	Then out of bounds should be stopped

Scenario: Program doesnt check out of bounds
	Given Spielsteine at the Corner
	When player 1 sets Spielstein on column 6
	Then It should be player2 turn

Scenario: Player cannot set Spielstein out of Bounds (MaxY+1)
	Given It's player 1 turn
	When player 1 sets Spielstein on column 7 of six
	Then outOfBounds should be true
