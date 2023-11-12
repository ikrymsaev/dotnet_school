FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app

EXPOSE 80

COPY ./Presentation/Presentation.csproj ./Presentation/Presentation.csproj
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/Infrastructure.csproj
COPY ./Application/Application.csproj ./Application/Application.csproj
COPY ./Domain/Domain.csproj ./Domain/Domain.csproj

RUN dotnet restore "./Presentation/Presentation.csproj" --disable-parallel

COPY . .
RUN dotnet build "./Presentation/Presentation.csproj" -c Release -o out
RUN dotnet publish "./Presentation/Presentation.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Presentation.dll"]





#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
#
#WORKDIR /app
#EXPOSE 80
#EXPOSE 5000
#
#COPY ./*.csproj ./
#RUN dotnet restore
#
#COPY . .
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /app
#COPY --from=builder /app/out .
#
#ENTRYPOINT ["dotnet", "WebApplication1.dll"]