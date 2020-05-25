Feature: OutOfBounds

@mytag
Scenario: Player chooses full column
	Given Column 3 is all occupied
	When player 2 chooses column 3
	Then out of bounds should be stopped
