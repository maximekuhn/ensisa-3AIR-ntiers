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