Feature: Denunciation

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

    Scenario: Admin responds to a denunciation with confirmation
        Given an unprocessed denunciation
        And an admin user
        When the admin submits a confirmation response with a retribution amount
        Then the response is added to the denunciation
        And the informant is eligible for the retribution

    Scenario: Attempt to respond to a denunciation that already has a response
        Given a denunciation with an existing response
        And an admin user
        When the admin attempts to respond to the denunciation
        Then the response submission fails
        And the error "the denunciation aleady has a response" should be raised

    Scenario: Admin views unprocessed denunciations
        Given an admin user
        When the admin requests the list of unprocessed denunciations
        Then the list is displayed in chronological order
        And includes timestamp, informant, suspect, offense, and if applicable, evasion country
        And does not include denunciations with VIP suspects