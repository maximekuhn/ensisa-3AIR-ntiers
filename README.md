# ensisa-3AIR-ntiers

## Version(s) utilisée(s)
- dotnet: 6

## Initialiser l'infrastructure
Installer l'outil dotnet/Entity Framework:
```shell
dotnet tool install --global dotnet-ef
```
> attention à bien installer la version 6 (--version 6)

Ensuite, se placer dans le répertoire `JeBalance.Infrastructure`.

Initialiser la migration:
```shell
dotnet ef migrations add initial --context DatabaseContext
```
> inutile si le fichier de migration existe déjà

Appliquer la migration:
```shell
dotnet ef database update --context DatabaseContext
```

Un fichier `LocalDatabase.db` doit s'être créé dans `JeBalance.Infrastructure`.

## Initialiser l'authentification
Se placer dans le répertoire `JeBalance.API.Securite.Shared`.  
Initialiser la migration:
```shell
dotnet ef migrations add initial --context AuthDbContext
```
> inutile si le fichier de migration existe déjà

Appliquer la migration:
```shell
dotnet ef database update --context AuthDbContext
```
