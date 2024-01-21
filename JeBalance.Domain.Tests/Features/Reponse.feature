Feature: Reponse

    Scenario: Repondre a une denonciation par une confirmation
        Given une denonciation existante sans reponse
        When une reponse de type "Confirmation" est ajoutee a la denonciation
        Then la denonciation a une reponse de type "Confirmation"
        And l'horodatage de la reponse est daté (horodatage)
        And la reponse contient le montant de la retribution

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
    #  Scenario: Repondre a une denonciation avec un montant de retribution negatif
    #    Given une denonciation existante sans reponse
    #    When une reponse de type "Confirmation" est ajoutee a la denonciation avec un montant de retribution negatif
    #    Then apparait le message d'erreur 'Le montant de retribution ne peut pas etre negatif'
    #    And la denonciation n'a pas de nouvelle reponse