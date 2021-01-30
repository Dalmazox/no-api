FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build
WORKDIR /source

EXPOSE 80

COPY *.sln .
COPY No.API/*.csproj ./No.API/
RUN dotnet restore

COPY No.API/. ./No.API/
WORKDIR /source/No.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build /app ./

RUN apk add --no-cache tzdata
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ENTRYPOINT ["dotnet", "No.API.dll"]