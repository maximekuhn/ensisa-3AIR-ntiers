Feature: Offense
	Simple calculator for adding two numbers

Scenario: Cannot create a tax evasion offense without a country
	Given the type is "TAXEVASION"
	And the country is "FRANCE"
	When the offense is created
	Then the error "Tax evasion must have a country" should be raised