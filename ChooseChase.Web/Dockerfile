FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChooseChase.Web/ChooseChase.Web.csproj", "ChooseChase.Web/"]
RUN dotnet restore "ChooseChase.Web/ChooseChase.Web.csproj"
COPY . .
WORKDIR "/src/ChooseChase.Web"
RUN dotnet build "ChooseChase.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChooseChase.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChooseChase.Web.dll"]
