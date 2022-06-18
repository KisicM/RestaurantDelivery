# RestaurantDelivery
Restaurant delivery web application
Client: Angular
Server: ASP.NET Web API

Add migration to postgresql:
    dotnet ef migrations add MigrationName --project Repository\Repository.csproj --startup-project WebApplication\WebApplication.csproj
Database update
    dotnet ef database update --project Repository/Repository.csproj --startup-project WebApplication/WebApplication.csproj