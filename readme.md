### En mall som vi kan testa lite för att komma igång med allt..

#### Setup:

```
cat > appsettings.Development.json << EOF
{
  "ConnectionStrings": {
    "sqlitedev": "Data Source=forge-energy.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
EOF
```

```
cat > appsettings.json << EOF
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
EOF
```

```
dotnet build
```

```
dotnet ef database update
```
