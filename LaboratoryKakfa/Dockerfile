#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LaboratoryKakfa/LaboratoryKakfa.csproj", "LaboratoryKakfa/"]
RUN dotnet restore "LaboratoryKakfa/LaboratoryKakfa.csproj"
COPY . .
WORKDIR "/src/LaboratoryKakfa"
RUN dotnet build "LaboratoryKakfa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaboratoryKakfa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaboratoryKakfa.dll"]