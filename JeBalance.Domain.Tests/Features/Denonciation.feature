Feature: Denonciation

    Scenario: Creation d'une denonciation pour evasion fiscale
        Given un type de delit "EvasionFiscale"
        And un pays d'evasion "France"
        And un informateur
        And un suspect
        When la denonciation est creee
        Then la denonciation est datée (horodatage)
        And la denonciation a un identifiant opaque
        And l'identifiant du suspect est le bon
        And l'identifiant de l'informateur est le bon

    Scenario: Impossible de créer une dénonciation si l'informateur est un calomniateur
        Given un type de delit "EvasionFiscale"
        And un pays d'evasion "France"
        And un informateur calomniateur déjà enrengistré
        And un suspect
        When la denonciation est creee
        Then apparait le message d'erreur 'Vous ne pouvez plus créer de dénonciations'

    Scenario: Impossible de créer une dénonciation pour évasion fiscale sans préciser un pays
        Given un type de delit "EvasionFiscale"
        And un informateur
        And un suspect
        When la denonciation est creee
        Then apparait le message d'erreur 'Une infraction d'evasion fiscale doit avoir un pays d'evasion'

    Scenario: La création d'une dénonciation doit créer le suspect dans la base s'il n'existe pas déjà
        Given un type de delit "EvasionFiscale"
        And un pays d'evasion "Suisse"
        And un informateur
        And un suspect
        When la denonciation est creee
        Then le suspect est ajouté à la base

    Scenario: La création d'une dénonciation doit créer l'informateur dans la base s'il n'existe pas déjà
        Given un type de delit "EvasionFiscale"
        And un pays d'evasion "Suisse"
        And un informateur
        And un suspect
        When la denonciation est creee
        Then l'informateur est ajouté à la base

    Scenario: Impossible de créer une denonciation si le suspect appartient à la liste des VIP
        Given un type de delit "EvasionFiscale"
        And un pays d'evasion "Suisse"
        And un informateur
        And un suspect appartenant aux VIP
        When la denonciation est creee
        Then apparait le message d'erreur 'Vous ne pouvez plus créer de dénonciations'

    Scenario: Créer une dénonciation contre un suspect VIP marque l'informateur comme calomniateur
        Given un type de delit "DissimulationDeRevenus"
        And un informateur
        And un suspect appartenant aux VIP
        When la denonciation est creee
        Then l'informateur est marqué comme calomniateur

    Scenario: Récupérer les dénonciations sans réponse avec pagination
        Given 3 dénonciations créées sans réponse
        And 2 d'entre elles ont reçu une réponse
        When une requête pour récupérer 1 dénonciations à partir de la page 0 sans réponse est faite
        Then 1 dénonciations sans réponse sont retournées
        And 1 dénonciations ont un ReponseId null