# Documentation développeur
Cette documentation décrit le fonctionnement du projet et les choix d'architecture.

# Table des matières
- [Documentation développeur](#documentation-développeur)
- [Table des matières](#table-des-matières)
  - [Architecture en couches](#architecture-en-couches)
  - [Détails sur chaque projet de la solution](#détails-sur-chaque-projet-de-la-solution)
  - [Domain Driven Design](#domain-driven-design)
  - [Pourquoi nous avons 3 APIs différentes ?](#pourquoi-nous-avons-3-apis-différentes-?)
  - [Pourquoi nous avons un seul projet UI ?](#pourquoi-nous-avons-un-seul-projet-ui-?)
  - [Traitement des calomniateurs](#traitement-des-calomniateurs)
  - [Traitement des calomniateurs et des dénonciations non traitées](#traitement-des-calomniateurs-et-des-denonciations-non-traitees)
  - [Tests](#tests)
  - [Méthodes de travail](#méthodes-de-travail)
  - [Axes d'amélioration](#axes-damélioration)

## Architecture en couches
Pour réaliser ce projet, nous avons respecté le modèle d'architecture en couche.
Étant donné le cahier des charges, nous avons décidé d'organiser le projet de la manière suivante:
- couche de présentation (`JeBalance.UI`)
- couche interface web (`JeBalance.API.Publique`, `JeBalance.API.Interne.Securisee`, `JeBalance.API.Secrete.Securisee`)
- couche logique métier (`JeBalance.Domain`)
- couche d'accès aux données (`JeBalance.Infrastructure`)

Grâce à cette architecture, nous pouvons faire évoluer et maintenir chaque couche indépendemment.
Nous pouvons adapter notre stratégie de déploiement à chaque couche:
- l'UI sur un serveur web
- l'infrastructure sur un serveur qui a une grande capacité de stockage
- ...

## Détails sur chaque projet de la solution
- `JeBalance.UI`
  - type de projet: **Blazor Server App**
- `JeBalance.Infrastructure`
  - type de projet: **Librairie de classes**
- `JeBalance.Infrastructure.Tests`
  - type de projet: **Tests XUnit**
- `JeBalance.Domain`
  - type de projet: **Librairie de classes**
- `JeBalance.Domain.Tests`
  - type de projet: **Tests XUnit + Specflow**
- `JeBalance.API.Securite.Shared`
  - type de projet: **Librairie de classes**
- `JeBalance.API.Secrete.Securisee`
  - type de projet: **ASP.NET Web Service**
- `JeBalance.API.Interne.Securisee`
  - type de projet: **ASP.NET Web Service**
- `JeBalance.API.Publique`
  - type de projet: **ASP.NET Web Service**

## Domain Driven Design
Nous avons placé le domaine au centre, en respectant le vocabulaire donné dans le cahier des charges (Ubiquitous Language).

Dans la classe `Denonciation`, nous avons choisi de mettre les identifiants des informateurs, du suspect et de la réponse pour se faciliter le développement.
Nous aurions pu mettre directement le `Suspect`, l'`Informateur` et la `Reponse`, mais l'implémentation de l'infrastructure aurait été plus compliquée.

## Pourquoi nous avons 3 APIs différentes ?
Pour respecter au mieux le cahier des charges, nous avons décider de créer 3 APIs différentes:
- `JeBalance.API.Publique`
  - création et consultation de dénonciation(s)
- `JeBalance.API.Interne.Securisee`
  - API dédiée à l'administration fiscale
  - permet de répondre aux dénonciations non traitées
- `JeBalance.API.Secrete.Securisee`
  - ajout/suppresion de VIP(s)

Avantages de cette approche (3 APIs distinctes):
- travail en parallèle
- séparation des responsabilités
- l'API publique sera plus sollicitée, on peut donc déployer plus de noeuds dédiés à la faire tourner

Inconvénient de cette approche:
- un petit peu de code dupliqué

Les APIs `Secrete` et `Interne` gèrent l'authentification des utilisateurs.
Pour ne pas dupliquer le code gérant la sécurité, nous avons créé le projet `JeBalance.API.Securite.Shared`.
Ce projet permet de factoriser la gestion de la sécurité utilisée dans les 2 APIs actuelles (et pourrait servir d'en d'autres APIs dans le futur).

## Pourquoi nous avons un seul projet UI ?
Le cahier des charges demandait une interface pour l'API `Publique`.  
Animés par l'envie d'apprendre, nous avons décidé d'ajouter des interface pour les APIs `Interne` et `Secrete`.
Nous les avons mises dans le même projet pour éviter d'avoir trop de code dupliqué.
Nous avons fait attention à ce qu'un utilisateur classique ne puisse pas accéder aux pages d'administration.

## Traitement des calomniateurs
Un `Informateur` peut devenir calomniateur si:
- il essaye de dénoncer un `VIP`
- il reçoit trois `Reponses` de type `Rejet`

## Traitement des calomniateurs et des dénonciations non traitées

Pour gérer l'état calomniateur, nous avons stocké un **booléen** dans la base de données.  
Grâce à cette méthode, nous n'avons pas besoin de re-calculer l'information à chaque fois que `Informateur` tente de faire une `Denonciation`.

Pour gérer la liste des dénonciations à restituer aux administrateurs fiscaux, qui doit contenir uniquement les dénonciations non traitées tout en gérant le cas des suspects considérés comme VIPs, nous avons mis en place une méthode spécifique dans le Repository. Cette méthode prend en paramètre une spécification conçue pour retenir uniquement les dénonciations non traitées.
Ensuite, nous avons employé cette méthode au niveau de l'infrastructure pour, dans un premier temps, filtrer la liste des dénonciations grâce à la spécification donnée en paramètre. Puis, directement dans l'infrastructure, nous avons filtré les suspects identifiés comme VIPs, avant de trier la liste en fonction de l’horodatage de création. Ceci assure que seules les dénonciations non traitées et non liées à des VIPs sont restituées, conformément aux exigences du cahier des charges.
Le filtrage et le tri est effectué directement dans la base de données pour optimiser l'envoi de données. De plus, le filtrage des VIPs est fait ici  pour maintenir la cohérence de la pagination.

## Tests
Nous avons écrit le code de chaque couche dans le but de le rendre facilement extensible et testable.  
Nous avons effectué des tests de validation dans le domaine en utilisant Specflow et Gherkin.  
Nous avons effectué des tests unitaires pour l'infrastructure (pour tester qu'on appelle bien l'ORM Entity Framework avec les bons paramètres).

## Méthodes de travail
Pour travailler en groupe de manière parallèle et efficace, nous avons utilisé:
- git pour la gestion des versions du code
  - création d'une branche par fonctionnalité
- GitHub
  - pour stocker le code
  - pour faire des Pull Requests et du Code Review
  - pour utiliser Github Actions (CI)
    - à chaque push
      - vérifie si le code est bien formaté
      - compile le code
      - joue l'ensemble des tests

## Axes d'amélioration
Dans l'infrastructure, nous avons créé une table pour:
- `Informateur`
- `Suspect`
- `VIP`

Nous aurions pu utiliser à notre avantage la séparation domaine/infrastructure et n'avoir qu'un seule repository `Personne` dans l'infrastructure.
Nous ne l'avons pour l'instant pas fait car il y a des légères différences entre `Suspect`, `Informateur` et `VIP`.
