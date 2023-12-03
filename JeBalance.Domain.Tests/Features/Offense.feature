Feature: Offense

    Scenario: Cannot create a tax evasion offense without a country
        Given the type is "TAXEVASION"
        And the country is "FRANCE"
        When the offense is created
        Then the error "Tax evasion must have a country" should be raised

    Scenario: Create a tax evasion offense
        Given the type is "TAXEVASION"
        And the country is "Switzerland"
        When the offense is created
        Then the offense is valid
        
    Scenario: Create an income concealer offense
        Given the type is "INCOMECONCEALER"
        When the offense is created
        Then the offense is valid
        
    Scenario: Create an income concealer offense with a country
        Given the type is "INCOMECONEALER"
        And the country is "Andorra"
        When the offense is created
        Then the offense is valid