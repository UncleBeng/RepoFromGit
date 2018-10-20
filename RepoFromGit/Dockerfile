FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RepoFromGit.csproj", "./"]
RUN dotnet restore "./RepoFromGit.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RepoFromGit.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RepoFromGit.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RepoFromGit.dll"]
