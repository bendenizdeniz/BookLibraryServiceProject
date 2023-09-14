FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookLibraryAPI/BookLibraryAPI.csproj", "BookLibraryAPI/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Entity/Entity.csproj", "Entity/"]
RUN dotnet restore "BookLibraryAPI/BookLibraryAPI.csproj"
COPY . .
WORKDIR "/src/BookLibraryAPI"
RUN dotnet build "BookLibraryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookLibraryAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookLibraryAPI.dll"]