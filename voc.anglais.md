# Vocabulaire (en anglais)

**IDenounce** : l'application dans son ensemble.

**Person** : individu identifié de manière unique par les élements suivants :
- Un **Firstname**
- Un **Lastname**
- Une **Address** composée de
    - Un **Numéro (de voie)**
    - Un **Nom de voie**
    - Un **Zipcode**
    - Un **City**

**Denunciation** : déclaration créée par un *Informant* non authentifié accusant un *Suspect* de dissimulation de revenus ou d'évasion fiscale.

**Denunciation identifier** : chaîne de caractères qui identifie de manière unique une Denunciation et grâce à laquelle un *Informant* peut consulter sa *Denunciation* et la possible *Response* associée.

**Informant** : *Person* correspondant à un utilisateur non authentifié mais identifié, créateur d'au moins une *Denunciation*.

**Suspect** : *Person* accusée par une *Denunciation* de *Dissimulation de revenus* ou d'*Evasion fiscale*.

**Offense** : attribut d'une *Denunciation* indiqué par l'*Informant* qui lors de sa création. Les valeurs possibles sont :
* **IncomeConcealer**
* **TaxEvasion**

**Evasion country** : attribut obligatoire d'une *Denunciation* de type *EvasionFiscale* indiquant dans quel pays le *Suspect* a dissimulé son argent.

**FISC Administration** : entité capable de consulter la liste des *Denunciations* sans Response et de créer des *Responses* à travers l'API dédiée.

**Response (to a Denunciation)** : retour unique et facultatif effectué sur une *Denunciation* par l'*Administration fiscale*.

**Type (of Response)** : caractérise une *Response* donnée par l'*Administration fiscale*. Les types possibles sont :
* *Confirmation*
* *Rejet*

**Unprocessed Denunciation** : *Denunciation* qui ne possède pas de *Response*.

**Retribution** : attribut obligatoire d'une *Response* de type *Confirmation* qui indique le montant en euro versé par l'*Administration fiscale* à l'*Informant* de la *Denunciation* confirmée.

**Slanderer** : *Person* qui n'est plus autorisée à créer de nouvelles Denunciations en tant qu'*Informant*.

**VIP** : *Person* dont qui ne peut pas apparaître en tant que *Suspect* dans la liste des *Denunciations* retournées à l'*Administration fiscale*.

**Admin** : utilisateur spécial pouvant administrer la liste des *VIP*.


Le cahier des charges fourni par les pouvoirs publics comporte les règles listées ci-dessous.

### Création d'une Denunciation

- Les utilisateur doivent passer par l'interface Web sans authentification pour créer les *Denunciations*.
- A la fin de la création de la *Denunciation*, on indique à l'utilisateur l'*Identifiant de la Denunciation*.
- L'*Identifiant de la Denunciation* doit être opaque et non prédictif.

### Suivi d'une Denunciation

- Un utilisateur peut consulter une *Denunciation* en utilisant l'*Identifiant de Denunciation* sur l'interface Web sans authentification.
- La consultation d'une *Denunciation* doit restituer les élements suivants :
    - L'horodatage de la *Denunciation*
    - Les informations identifiant l'*Informant*
    - Les informations identifiant le *Suspect*
    - Le *Délit*
    - Si applicable, le *Pays d'évasion*
    - Si applicable la *Response* :
        - L'horodatage de la *Response*
        - Le *Type de Response*
        - Si applicable, le montant de la *Rétribution*

### Consultation des Denunciations non traitées

- Seule l'*Administration fiscale* peut consulter la liste des *Denunciations non traitées*.
- L'*Administration fiscale* peut consulter la liste des *Denunciations non traitées* en utilisant l'API REST sécurisée dédiée.
- La liste des *Denunciations* sans *Response* doit être paginée.
- La liste des *Denunciations* sans *Response* doit comporter l'horodatage de sa création, l'*Informant*, le *Suspect*, le *Délit* et le *Pays d'évasion* si applicable.
- La liste des *Denunciations non traitées* doit être triée par ordre d'horodatage création.
- Les *Denunciations* dont le *Suspect* est un *VIP* ne doivent pas être restituées dans la liste.

### Répondre à une Denunciation

- Seule l'*Administration fiscale* peut créer des *Responses* sur les *Denunciations*.
- L'*Administration fiscale* peut créer une *Response* sur une *Denunciations* en utilisant l'API REST sécurisée dédiée.
- Il n'est pas possible de répondre à une *Denunciation* qui possède déjà une *Response*.

### Administration de la liste des VIP

- Seuls les *Administrateurs* peuvent modifier la liste des *VIP*.
- Les *Administrateurs* peuvent consulter la liste des *VIP* en utilisant l'API sécurisée dédiée.
- Les *Administrateurs* peuvent ajouter ou supprimer des *Persons* à la liste des *VIP* en utilisant l'API sécurisée dédiée.

### Traitement des calomniateurs

- Il n'est pas possible de créer une *Denunciation* avec un *Informant* appartenant à la liste des *Calomniateurs*. Si un utilisateur tente de créer une telle *Denunciation*, l'application lui restitue une message d'erreur lui indiquant qu'il n'est plus autorisé à créer des *Denunciations*.
- Tout *Informant* ayant créé au moins 3 *Denunciations* ayant reçu une *Response* de type *Rejet* est automatiquement ajouté à la liste des *Calomniateurs*.
- Tout *Informant* ayant créé au moins une *Denunciation* dont le *Suspect* faisait partie de la liste des *VIP* au moment de sa création est automatiquement ajouté à la liste des *Calomniateurs*.