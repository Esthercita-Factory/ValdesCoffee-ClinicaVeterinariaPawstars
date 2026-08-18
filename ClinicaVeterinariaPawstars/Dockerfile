FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["ClinicaVeterinariaPawstars.csproj", "ClinicaVeterinariaPawstars"]

RUN dotnet restore "ClinicaVeterinariaPawstars.csproj"

COPY . . 

WORKDIR "src/ClinicaVeterinariaPawstars"

RUN dotnet publish "ClinicaVeterinariaPawstars.csproj" 
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+8080

ENTRYPOINT ["dotnet", "ClinicaVeterinariaPawstars.dll"]