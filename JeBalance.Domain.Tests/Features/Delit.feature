Feature: Delit
#
#    Scenario: Impossible de creer un delit de type EvasionFiscale sans pays
#        Given un type "EvasionFiscale"
#        When la demande de creation de delit est envoyee
#        Then le message d erreur "L'evasion fiscale doit avoir un pays" doit etre generee
#
#    Scenario: Creation d'un delit de type EvasionFiscale
#        Given un type "EvasionFiscale"
#        And un pays "Suisse"
#        When la demande de creation de delit est envoyee
#        Then le delit doit etre cree
#		 And le type du delit est "EvasionFiscale"
#		 And le pays du delit est "Suisse"
#
#    Scenario: Creation d'un delit de type DissimulationDeRevenus
#        Given un type "DissimulationDeRevenus"
#        When la demande de creation de delit est envoyee
#        Then le delit doit etre cree
#		 And le type du delit est "DissimulationDeRevenus"
#
#    Scenario: Creation d'un delit de type DissimulationDeRevenus avec un pays
#        Given un type "DissimulationDeRevenus"
#        And le pays "Andorre"
#        When la demande de creation de delit est envoyee
#        Then le delit doit etre cree
#		 And le type du delit est "DissimulationDeRevenus"
#		 And le pays du delit est "Andorre"