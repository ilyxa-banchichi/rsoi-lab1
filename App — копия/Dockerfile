ARG CONFIGURATION
FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG CONFIGURATION
RUN echo ${CONFIGURATION}
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ./*.sln ./
COPY . .

ARG CONFIGURATION
RUN echo ${CONFIGURATION}

RUN dotnet restore 
WORKDIR /src/src/G21.API
RUN dotnet build "G21.API.csproj" -c "$CONFIGURATION" -o /app/build

ARG CONFIGURATION
RUN echo ${CONFIGURATION}

FROM build AS publish
RUN dotnet publish "G21.API.csproj" -c "$CONFIGURATION" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "G21.API.dll"]