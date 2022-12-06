#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ContentMgmtCore/ContentMgmtCore.csproj", "ContentMgmtCore/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "ContentMgmtCore/ContentMgmtCore.csproj"
COPY . .
WORKDIR "/src/ContentMgmtCore"
RUN dotnet build "ContentMgmtCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContentMgmtCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContentMgmtCore.dll"]