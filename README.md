# ensisa-3AIR-ntiers

## Initialiser l'infrastructure
Installer l'outil dotnet:
```shell
dotnet tool install --global dotnet-ef
```

Initialiser la migration:
```shell
dotnet ef migrations add initial --context DatabaseContext
```

Appliquez la migration:
```shell
dotnet ef database update --context DatabaseContext
```

Un fichier `LocalDatabase.db` doit s'être créé dans `JeBalance.Infrastructure`.
