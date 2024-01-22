Feature: Personne
#
#    Scenario: Creer une personne
#        Given un prenom "Batuhan"
#        And un nom "GOKER"
#        And une adresse "7 rue du KFC blessant, 68200 Colonel Street"
#        When une personne est creee
#        Then la personne est ajoutee a la liste des personnes
#        And le prenom de la personne est "Batuhan"
#        And le nom de la personne est "GOKER"
#        And l'adresse est "7 rue du KFC blessant, 68200 Colonel Street"
#

    Scenario: Ajouter une personne dans la liste des informateurs
        Given une personne
        When une personne cree une denonciation
        Then la personne est ajoutee a la liste des informateurs

    #    Scenario: Impossible d'ajouter une personne dans la liste des informateurs
    #        Given une personne
    #        When la personne n'a pas fait de denonciation
    #        Then la personne n'est pas ajoutee dans la liste des informateurs
    #
    #    Scenario: Ajouter une personne dans la liste des suspects
    #        Given une personne
    #        When une personne a ete accusee par une denonciation
    #        Then la personne est ajoutee dans la liste des suspects
    #
    #    Scenario: Ajout d'une personne dans la liste des VIP par l'administrateur
    #        Given une personne
    #        And un administrateur
    #        When l'administrateur ajoute une personne dans la liste des VIP
    #        Then le personne est ajoutee dans la liste des VIP
    #
    #    Scenario: Suppression d'une personne dans la liste des VIP par l'administrateur
    #        Given une personne
    #        And un administrateur
    #        When l'administrateur supprime la personne de la liste des VIP
    #        Then la personne est supprimee de la liste des VIP
    #
    #    Scenario: Un utilisateur non administrateur ne peut pas ajouter une personne dans la liste des VIP
    #        Given une personne
    #        And un utilisateur non administrateur
    #        When l'utilisateur non administrateur supprime la personne de la liste des VIP
    #        Then le message d'erreur "Vous n'avez pas les autorisations necessaire pour effectuer cette operation" doit etre generee
    #
    #    Scenario: Identification et restriction d'un calomniateur
    #        Given une personne etant identifiee comme calomniateur
    #        When la peronne tente de soumettre une nouvelle denonciation
    #        Then la personne est empechee de le faire
    #        And le message d'erreur "Vous n'etes plus autorise a creer des denonciations" doit etre generee
    #
    #    Scenario: Ajouter un informateur a la liste des calomniateurs apres 3 denonciations rejetees
    #        Given un informateur ayant soumis plusieurs denonciations
    #        And au moins trois de ces denonciations ont recu une reponse de type rejet
    #        Then l'informateur est automatiquement ajoute a la liste des calomniateurs
    #
    #    Scenario: Ajout d'un informateuer a la liste des calomniateurs pour denonciation d'un membre VIP
    #        Given un informateur soumet une denonciation impliquant un membre VIP
    #        Then l'informateur est automatiquement ajoute a la liste des calomniateurs