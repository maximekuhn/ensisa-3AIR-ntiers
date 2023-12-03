Feature: Person

    Scenario: Create a person
        Given the firstname is "Batuhan"
        And the lastname is "GOKER"
        And an address
        When the person is created
        And the person firstname is "Batuhan"
        And the person lastname is "GOKER"
        Then the person is added to the person list

    Scenario: Add a person to informent list
        Given a person
        When person creates a denunciation
        Then the person is added to the informent list

    Scenario: Can not add person in the informent list
        Given person
        When person has not denunciation
        Then the person is not added to the informent list

    Scenario: Added person in suspect list
        Given person
        When person has been accused by a denunciation
        Then the person is added to the suspect list

    Scenario: Admin adds a person to the VIP list
        Given a person
        And an admin user
        When the admin adds the person to the VIP list
        Then the person is added to the VIP list

    Scenario: Admin removes a person in the VIP list
        Given a person
        And an admin user
        When the admin removes the person in the VIP list
        Then the person is removed to the VIP list

    Scenario: A non-admin person cannot add another person in the VIP list
        Given a person
        And an non-adim person
        When the person removes the person in the VIP list
        Then the error "You are not allowed to do that" should be raised

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