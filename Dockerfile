FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY UserProject.API/*.csproj ./UserProject.API/
COPY UserProject.Data/*.csproj ./UserProject.Data/
COPY UserProject.Core/*.csproj ./UserProject.Core/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY UserProject.API/. ./UserProject.API/
COPY UserProject.Data/. ./UserProject.Data/
COPY UserProject.Core/. ./UserProject.Core/ 
#
WORKDIR /app/UserProject.API
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/UserProject.API/out ./
ENTRYPOINT ["dotnet", "UserProject.API.dll"]