Feature: Reponse

    Scenario: Répondre à une dénonciation par une confiration et une retribution
        Given une dénonciation existante sans réponse
        When une réponse de type 'Confirmation'  avec une retribution de '1000' euros est ajoutée à la dénonciaton
        Then la dénonciation contient l'identifiant de la réponse
        And la réponse est de type 'Confirmation'
        And la réponse contient une retribution de '1000' euros
        And la réponse est datée (horodatage)
        
    #  Scenario: Repondre a une denonciation par un rejet
    #    Given une denonciation existante sans reponse
    #    When une reponse de type "Rejet" est ajoutee a la denonciation
    #    Then la denonciation a une reponse de type "Rejet"
    #    And l'horodatage de la reponse est daté (horodatage)
    #    And le montant de retribution est null
    #
    #  Scenario: Impossible de repondre a une denonciation qui a deja une reponse
    #    Given une denonciation existante avec une reponse associée
    #    When une reponse est ajoutee a la denonciation
    #    Then apparait le message d'erreur 'Cette denonciation a deja une reponse'
    #
    Scenario: Repondre a une denonciation avec un montant de retribution negatif
      Given une dénonciation existante sans réponse
      When une réponse de type 'Confirmation'  avec une retribution de '-50' euros est ajoutée à la dénonciaton
      Then apparait le message d erreur 'Le montant de retribution ne peut pas etre negatif'