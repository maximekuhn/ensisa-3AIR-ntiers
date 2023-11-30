Feature: Denunciation
	Simple calculator for adding two numbers

Scenario: Create a tax evasion denunciation
	Given a suspect
	And an informant
	And the offense is "TAXEVASION" 
	And the evasion country is "FRANCE"
	When the denunciation is created
	Then the denunciation has an id
	And the denunciation has a timestamp
	And the denunciation is added to the WIP list

Scenario: Create a income concealer denunciation
	Given a suspect
	And an informant
	And the offense is "INCOMECONCEALER" 
	And the evasion country is "FRANCE"
	When the denunciation is created
	Then the denunciation has an id
	And the denunciation has a timestamp
	And the denunciation is added to the WIP list

Scenario: Can not create a denunciation without country
	Given a suspect
	And an informant
	And the offense is "TAXEVASION" 
	When the denunciation is created
	Then the error "Tax evasion must have a country" should be raised
	
Scenario: Can not create a denunciation against a VIP
	Given a suspect in VIP list
	And an informant
	And an offense
	When the denunciation is created
	Then the denunciation is not added to the WIP list

Scenario: Generation of a unique, non-predictive denunciation identifier
	Given a person is filling in the fields
	When they submit a denunciation with valid details
	Then the denunciation is successfully created
	And a unique, non-predictive denunciation identifier is generated

Scenario: User checks the status of a denunciation
	 Given a denunciation identifier
	 When the denunciation is retrieved
	 Then the detailed status of the denunciation is displayed
	 And the details include timestamp, informant, suspect, offense, and if applicable, evasion country and response

Scenario: Track a denunciation with an invalid identifier
	 Given an invalid denunciation identifier
	 When the denunciation is retrieved
	 Then the error "Invalid identifier" should be raised

Scenario: Identification and restriction of a calumniator
	Given a person has been identified as a calumniator
	When they attempt to submit a new denunciation
	Then they are prevented from doing so
	And the error "You are no longer allowed to create denunciations" should be raised

Scenario: Add an Informant to the Calumniators list after 3 rejected denunciations
    Given an Informant has created Denunciations
    And at least 3 Denunciations have received a Rejection Response
    Then the Informant is automatically added to the Calumniators list

Scenario: Add an Informant to the Calumniators list after reporting a VIP member
    Given an Informant has created a denunciation
    And the suspect is a VIP
    Then the Informant is automatically added to the Calumniators list
