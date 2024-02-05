# Cahier des charges JeBalance

## Concept

Face au problème de l'évasion fiscale et de la dissimulation de revenus, les pouvoirs publics souhaitent développer un réseau de dénonciation citoyenne.

Pour inciter les citoyens à participer, l'administration fiscale est prête à rémunérer chaque dénonciateur en fonction du montant récupéré grâce à la dénonciation.

Un nouveau site internet, **jebalance.gouv.fr**, doit permettre à chaque citoyen de dénoncer facilement les cas d'évasion fiscale et de récolter sa part de l'argent récupéré.

Cependant, certains *VIP* au dessus de tout soupçon ne doivent pas être la cible de contrôles fiscaux. Le système doit bien évidemment ignorer les dénonciations *calomnieuses* dont elles pourraient faire l'objet.

Votre société a remporté l'appel d'offre des pouvoirs publics et vous êtes chargés de **concevoir** et **développer** l'application.

## Objectifs

jebalance.gouv.fr comportera trois points d'entrée :
* Une interface Web publique sans authentification
    * Création des dénonciations
    * Consultation du statut de la dénonciation
* Une API interne sécurisée réservée à l'inspection fiscale
    * Collecte de la liste des dénonciations non traitées
    * Réponse aux dénonciations
* Une API secrète sécurisée réservée aux administrateurs de l'application
    * Administration de la liste des VIP

## Contraintes techniques

L'appel d'offre comporte les contraintes techniques suivantes :
- L'application doit être écrite en C# et doit s'appuyer sur le framework .NET 6 ou supérieur
- L'application doit être modulaire afin de pouvoir adapter pour chaque composant :
    - Le niveau de sécurité
    - Les ressources matérielles (CPU, bande passante, mémoire...)
    - La fréquence des mises à jour
- Le code métier doit respecter les principes de l'approche **DDD**
- L'architecture technique de chaque composant doit être maitenable et testable
- Les API doivent être des Web Services respectant l'approche **REST**
- L'accès aux API sécurisées doit nécessiter un **JWT** signé par l'algorithme **HMACSHA256**
- La base de données utilisée doit être **SQLite**
- L'accès à la base doit se faire à traver l'ORM **Entity Framework**

## Vocabulaire commun (en français)

**JeBalance** : l'application dans son ensemble.

**Personne** : individu identifié de manière unique par les élements suivants :
- Un **Prénom**
- Un **Nom**
- Une **Adresse** composée de
    - Un **Numéro (de voie)**
    - Un **Nom de voie**
    - Un **Code postal**
    - Un **Nom de commune**

**Dénonciation** : déclaration créée par un *Informateur* non authentifié accusant un *Suspect* de dissimulation de revenus ou d'évasion fiscale.

**Identifiant de dénonciation** : chaîne de caractères qui identifie de manière unique une dénonciation et grâce à laquelle un *Informateur* peut consulter sa *Dénonciation* et la possible *Réponse* associée.

**Informateur** : *Personne* correspondant à un utilisateur non authentifié mais identifié, créateur d'au moins une *Dénonciation*.

**Suspect** : *Personne* accusée par une *Dénonciation* de *Dissimulation de revenus* ou d'*Evasion fiscale*.

**Délit** : attribut d'une *Dénonciation* indiqué par l'*Informateur* qui lors de sa création. Les valeurs possibles sont :
* **DissimulationDeRevenus**
* **EvasionFiscale**

**Pays d'évasion** : attribut obligatoire d'une *Dénonciation* de type *EvasionFiscale* indiquant dans quel pays le *Suspect* a dissimulé son argent.

**Administration fiscale** : entité capable de consulter la liste des *Dénonciations* sans réponse et de créer des *Réponses* à travers l'API dédiée.

**Réponse (à une Dénonciation)** : retour unique et facultatif effectué sur une *Dénonciation* par l'*Administration fiscale*.

**Type (de Réponse)** : caractérise une *Réponse* donnée par l'*Administration fiscale*. Les types possibles sont :
* *Confirmation*
* *Rejet*

**Dénonciation non traitée** : *Dénonciation* qui ne possède pas de *Réponse*.

**Retribution** : attribut obligatoire d'une *Réponse* de type *Confirmation* qui indique le montant en euro versé par l'*Administration fiscale* à l'*Informateur* de la *Dénonciation* confirmée.

**Calomniateur** : *Personne* qui n'est plus autorisée à créer de nouvelles dénonciations en tant qu'*Informateur*.

**VIP** : *Personne* dont qui ne peut pas apparaître en tant que *Suspect* dans la liste des *Dénonciations* retournées à l'*Administration fiscale*.

**Administrateur** : utilisateur spécial pouvant administrer la liste des *VIP*.

## Règles de gestion

Le cahier des charges fourni par les pouvoirs publics comporte les règles listées ci-dessous.

### Création d'une dénonciation

- Les utilisateur doivent passer par l'interface Web sans authentification pour créer les *Dénonciations*.
- A la fin de la création de la *Dénonciation*, on indique à l'utilisateur l'*Identifiant de la dénonciation*.
- L'*Identifiant de la dénonciation* doit être opaque et non prédictif.

### Suivi d'une dénonciation

- Un utilisateur peut consulter une *Dénonciation* en utilisant l'*Identifiant de dénonciation* sur l'interface Web sans authentification.
- La consultation d'une *Dénonciation* doit restituer les élements suivants :
    - L'horodatage de la *Dénonciation*
    - Les informations identifiant l'*Informateur*
    - Les informations identifiant le *Suspect*
    - Le *Délit*
    - Si applicable, le *Pays d'évasion*
    - Si applicable la *Réponse* :
        - L'horodatage de la *Réponse*
        - Le *Type de Réponse*
        - Si applicable, le montant de la *Rétribution*

### Consultation des dénonciations non traitées

- Seule l'*Administration fiscale* peut consulter la liste des *Dénonciations non traitées*.
- L'*Administration fiscale* peut consulter la liste des *Dénonciations non traitées* en utilisant l'API REST sécurisée dédiée.
- La liste des *Dénonciations* sans *Réponse* doit être paginée.
- La liste des *Dénonciations* sans *Réponse* doit comporter l'horodatage de sa création, l'*Informateur*, le *Suspect*, le *Délit* et le *Pays d'évasion* si applicable.
- La liste des *Dénonciations non traitées* doit être triée par ordre d'horodatage création.
- Les *Dénonciations* dont le *Suspect* est un *VIP* ne doivent pas être restituées dans la liste.

### Répondre à une dénonciation

- Seule l'*Administration fiscale* peut créer des *Réponses* sur les *Dénonciations*.
- L'*Administration fiscale* peut créer une *Réponse* sur une *Dénonciations* en utilisant l'API REST sécurisée dédiée.
- Il n'est pas possible de répondre à une *Dénonciation* qui possède déjà une *Réponse*.

### Administration de la liste des VIP

- Seuls les *Administrateurs* peuvent modifier la liste des *VIP*.
- Les *Administrateurs* peuvent consulter la liste des *VIP* en utilisant l'API sécurisée dédiée.
- Les *Administrateurs* peuvent ajouter ou supprimer des *Personnes* à la liste des *VIP* en utilisant l'API sécurisée dédiée.

### Traitement des calomniateurs

- Il n'est pas possible de créer une *Dénonciation* avec un *Informateur* appartenant à la liste des *Calomniateurs*. Si un utilisateur tente de créer une telle *Dénonciation*, l'application lui restitue une message d'erreur lui indiquant qu'il n'est plus autorisé à créer des *Dénonciations*.
- Tout *Informateur* ayant créé au moins 3 *Dénonciations* ayant reçu une *Réponse* de type *Rejet* est automatiquement ajouté à la liste des *Calomniateurs*.
- Tout *Informateur* ayant créé au moins une *Dénonciation* dont le *Suspect* faisait partie de la liste des *VIP* au moment de sa création est automatiquement ajouté à la liste des *Calomniateurs*.