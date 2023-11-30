Feature: Person

Scenario: Create a person
	Given the firstname is "Batuhan"
	And the lastname is "GOKER"
	And an address
	When the person is created
	Then the person is added to the person list

Scenario: Added person in informent list
	Given a person
	When person has created one or more denunciation
	Then the person is added to the informent list

Scenario: Can not add person in the informent list
	Given person
	When person has not denunciation
	Then the person is not added to the informent list

Scenario: Added person in suspect list
	Given person
	When person has been accused by a denunciation
	Then the person is added to the suspect list

