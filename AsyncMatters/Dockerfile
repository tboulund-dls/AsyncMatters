FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AsyncMatters/AsyncMatters.csproj", "AsyncMatters/"]
RUN dotnet restore "AsyncMatters/AsyncMatters.csproj"
COPY . .
WORKDIR "/src/AsyncMatters"
RUN dotnet build "AsyncMatters.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsyncMatters.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsyncMatters.dll"]
