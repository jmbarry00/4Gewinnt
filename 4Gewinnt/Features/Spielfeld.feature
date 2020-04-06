Feature: Spielfeld

@mytag
Scenario: set Position
	Given I have entered 4 into the x-position(spalte) and 5 into the y-position(zeile)
	When I call the function FeldIstBesetzt on this position  
	Then result should be true