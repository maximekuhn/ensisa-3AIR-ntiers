Feature: Reponse

    Scenario: Répondre à une dénonciation par une confirmation et une retribution
        Given une dénonciation existante sans réponse
        When une réponse de type 'Confirmation'  avec une retribution de '1000' euros est ajoutée à la dénonciaton
        Then la dénonciation contient l'identifiant de la réponse
        And la réponse est de type 'Confirmation'
        And la réponse contient une retribution de '1000' euros
        And la réponse est datée (horodatage)

    Scenario: Repondre a une denonciation par un rejet
        Given une dénonciation existante sans réponse
        When une réponse de type 'Rejet' est ajoutée à la dénonciation
        Then la réponse est de type 'Rejet'
        And la réponse est datée (horodatage)
        And la réponse contient une retribution nulle

    Scenario: Le montant de la retribution pour une réponse de type Rejet n'est pas pris en compte
        Given une dénonciation existante sans réponse
        When une réponse de type 'Rejet'  avec une retribution de '599' euros est ajoutée à la dénonciaton
        Then la réponse est de type 'Rejet'
        And la réponse est datée (horodatage)
        And la réponse contient une retribution nulle

    Scenario: Impossible de répondre a une dénonciation qui a déjà une réponse de type rejet
        Given une dénonciation existante avec une réponse
        When une réponse de type 'Rejet' est ajoutée à la dénonciation
        Then apparait le message d erreur 'Impossible de répondre à une dénonciation qui a déjà une réponse'

    Scenario: Repondre a une denonciation avec un montant de retribution negatif
        Given une dénonciation existante sans réponse
        When une réponse de type 'Confirmation'  avec une retribution de '-50' euros est ajoutée à la dénonciaton
        Then apparait le message d erreur 'Le montant de retribution ne peut pas etre negatif'