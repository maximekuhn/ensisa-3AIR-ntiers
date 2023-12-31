Feature: Denonciation

    Scenario: Creation d'une denonciation pour evasion fiscale
        Given un suspect
        And un informateur
        And un delit de type "EvasionFiscale"
        And un pays d'evasion "France"
        When la denonciation est creee
        Then la denonciation a un identifiant
        And le statut de la denonciation est "Denonciation non traitee"

    Scenario: La denonciation pour evasion fiscale doit avoir les bons parametres
        Given un suspect
        And un informateur
        And un delit de type "EvasionFiscale"
        And un pays d'evasion "France"
        When la denonciation est creee
        Then le type de delit de la denonciation est "EvasionFiscale"
        And le pays d'evasion est "France"

    Scenario: Impossible de creer une denonciation pour evasion fiscale sans pays
        Given un suspect
        And un informateur
        And un delit de type "EvasionFiscale"
        When la denonciation est creee
        Then le message d'erreur "Une infraction d'evasion fiscale doit avoir un pays d'evasion" doit etre generee
    #
    #    Scenario: Creation d'une denonciation
    #        Given un suspect
    #        And un informateur
    #        And un delit
    #        When la denonciation est creee
    #        Then la denonciation a un identifiant
    #        And la denonciation a un horodatage
    #        And la denonciation est ajoutee a la liste WIP
    #
    #    Scenario: Impossible de creer une denonciation contre un VIP
    #        Given un suspect etant dans la liste des VIP
    #        And un informateur
    #        And un delit
    #        When la denonciation est creee
    #        Then la denonciation n'est pas ajoutee dans la liste des WIP
    #
    #    Scenario: Generation d'un identifiant de denonciation unique et non predictif
    #        Given une personne remplissant les champs
    #        When elle soumet une denonciation avec des details valides
    #        Then la denonciation est creee avec succes
    #        And un identifiant de denonciation unique et non predictif est genere
    #
    #    Scenario: Un utilisateur verifie le statut d'une denonciation
    #        Given un identifiant de denonciation
    #        When la denonciation est retrouvee
    #        Then le statut detaille de la denonciation est affiche
    #        And les details incluent horodatage, informateur, suspect, infraction, et si applicable, pays d'evasion et reponse
    #
    #    Scenario: Suivre une denonciation avec un identifiant invalide
    #        Given un identifiant de denonciation invalide
    #        When la denonciation est retrouvee
    #        Then le message d'erreur "Identifiant de denonciation invalide" doit etre generee
    #
    #    Scenario: Un administrateur repond a une denonciation avec confirmation
    #        Given une denonciation non traitee
    #        And un administrateur
    #        When l'administrateur soumet une reponse de confirmation avec un montant de retribution
    #        Then la reponse est ajoutee a la denonciation
    #        And l'informateur est eligible pour la retribution
    #
    #    Scenario: Tentative de reponse a une denonciation qui a deja une reponse
    #        Given une denonciation avec une reponse existante
    #        And un administrateur
    #        When l'administrateur tente de repondre a la denonciation
    #        Then la soumission de reponse echoue
    #        Then le message d'erreur "La denonciation a deja une reponse" doit etre generee
    #
    #    Scenario: Un administrateur consulte les denonciations non traitees
    #        Given un administrateur
    #        When l'administrateur demande la liste des denonciations non traitees
    #        Then la liste est affichee par ordre chronologique
    #        And inclut horodatage, informateur, suspect, infraction, et si applicable, pays d'evasion
    #        And n'inclut pas les denonciations avec des suspects VIP