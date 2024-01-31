# ensisa-3AIR-ntiers

## Table des matières
- [ensisa-3AIR-ntiers](#ensisa-3air-ntiers)
  - [Table des matières](#table-des-matières)
  - [A propos](#a-propos)
  - [Structure du projet](#structure-du-projet)
  - [Documentation développeur](#documentation-développeur)
  - [Documentation utilisateur](#documentation-utilisateur)

## A propos
Projet N-Tiers, ENSISA 3A IR.
Membres du groupe:
- GRAINCA Albi (albi.grainca@uha.fr)
- GÖKER Batuhan (batuhan.goker@uha.fr)
- KUHN Maxime (maxime.kuhn1@uha.fr)

## Structure du projet
```
.
├── JeBalance.API.Interne.Securisee     # API interne pour répondre aux dénonciations non traitées
├── JeBalance.API.Publique              # API publique pour dénoncer / consulter une dénonciation
├── JeBalance.API.Secrete.Securisee     # API secrète pour administrer les VIPs
├── JeBalance.API.Securite.Shared       # code commun pour gérer la sécurité des APIs publique et secrète
├── JeBalance.Domain                    # domaine (logique métier)
├── JeBalance.Domain.Tests              # tests d'acceptance du domaine
├── JeBalance.Infrastructure            # interaction avec la base de données
├── JeBalance.Infrastructure.Tests      # tests unitaires pour utilisation de l'ORM
├── JeBalance.UI                        # appication web blazor (frontend)
├── JeBalance.sln                       
└── README.md                           # ce fichier

10 directories, 3 files
```

## Documentation développeur
Pour comprendre comment fonctionne le projet, consultez [cette documentation](./documentation/DEV_DOC.md).

## Documentation utilisateur
Pour déployer et utiliser le projet, consultez [cette documentation](./documentation/USER_DOC.md).
