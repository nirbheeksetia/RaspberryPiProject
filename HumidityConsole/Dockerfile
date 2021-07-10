FROM mcr.microsoft.com/dotnet/sdk:5.0.301-buster-slim-amd64 AS build-env
WORKDIR /app

 

COPY *.csproj ./
RUN dotnet restore

 

COPY . ./
RUN dotnet publish -c Release -o out

 

FROM mcr.microsoft.com/dotnet/sdk:5.0.301-buster-slim-arm32v7
WORKDIR /app
COPY --from=build-env /app/out ./

 

#RUN useradd -ms /bin/bash moduleuser
#USER moduleuser

 

ENTRYPOINT ["dotnet", "HumidityConsole.dll"]