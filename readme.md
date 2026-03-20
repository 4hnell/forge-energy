### En mall som vi kan testa lite för att komma igång med allt..

touch appsettings.Development.json

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

touch appsettings.json

{
"Logging": {
"LogLevel": {
"Default": "Information",
"Microsoft.AspNetCore": "Warning"
}
},
"AllowedHosts": "\*"
}
