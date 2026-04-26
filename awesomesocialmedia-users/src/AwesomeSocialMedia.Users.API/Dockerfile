#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/AwesomeSocialMedia.Users.API/AwesomeSocialMedia.Users.API.csproj", "src/AwesomeSocialMedia.Users.API/"]
COPY ["src/AwesomeSocialMedia.Users.Application/AwesomeSocialMedia.Users.Application.csproj", "src/AwesomeSocialMedia.Users.Application/"]
COPY ["src/AwesomeSocialMedia.Users.Core/AwesomeSocialMedia.Users.Core.csproj", "src/AwesomeSocialMedia.Users.Core/"]
COPY ["src/AwesomeSocialMedia.Users.Infrastructure/AwesomeSocialMedia.Users.Infrastructure.csproj", "src/AwesomeSocialMedia.Users.Infrastructure/"]
RUN dotnet restore "src/AwesomeSocialMedia.Users.API/AwesomeSocialMedia.Users.API.csproj"
COPY . .
WORKDIR "/src/src/AwesomeSocialMedia.Users.API"
RUN dotnet build "AwesomeSocialMedia.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeSocialMedia.Users.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeSocialMedia.Users.API.dll"]