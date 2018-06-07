FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Pips.NET.sln ./
COPY Pips/Pips.csproj Pips/
COPY Pips.Test/Pips.Test.csproj Pips.Test/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
RUN dotnet test Pips.Test
WORKDIR /src/Pips
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pips.dll"]
