FROM mcr.microsoft.com/dotnet/sdk:6.0.202-focal AS build
WORKDIR /src
#COPY ["BookShare.Api/BookShare.Api.csproj", "BookShare.Api/"]
 COPY . .

RUN dotnet restore "BookShare.Api/BookShare.Api.csproj" --disable-parallel
# RUN dotnet build "BookShare.Api/BookShare.Api.csproj" -c Release -o /app/build
RUN dotnet publish "BookShare.Api/BookShare.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "BookShare.Api.dll"]
