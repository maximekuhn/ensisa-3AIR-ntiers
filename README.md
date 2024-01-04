# ensisa-3AIR-ntiers

## Initialiser l'infrastructure
Installer l'outil dotnet:
```shell
dotnet tool install --global dotnet-ef
```
> attention à bien installer la version 6 (--version 6)

Initialiser la migration:
```shell
dotnet ef migrations add initial --context DatabaseContext
```
> inutile si le fichier de migration existe déjà

Appliquez la migration:
```shell
dotnet ef database update --context DatabaseContext
```

Un fichier `LocalDatabase.db` doit s'être créé dans `JeBalance.Infrastructure`.
