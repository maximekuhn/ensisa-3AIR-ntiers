Feature: Denunciation
	Simple calculator for adding two numbers

Scenario: Create a denunciation
	Given a suspect
	And an informant
	And an offense
	When the denunciation is created
	Then the denunciation has an id
	And the denunciation has a timestamp
	And the denunciation is added to the WIP list
	
Scenario: Can not create a denunciation against a VIP
	Given a suspect in VIP list
	And an informant
	And an offense
	When the denunciation is created
	Then the denunciation is not added to the WIP list