#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StudyProject.Webapi/StudyProject.Webapi.csproj", "StudyProject.Webapi/"]
COPY ["StudyProject.Domain/StudyProject.Domain.csproj", "StudyProject.Domain/"]
COPY ["StudyProject.Infrastructure/StudyProject.Infrastructure.csproj", "StudyProject.Infrastructure/"]
COPY ["StudyProject.Application/StudyProject.Application.csproj", "StudyProject.Application/"]
RUN dotnet restore "StudyProject.Webapi/StudyProject.Webapi.csproj"
COPY . .
WORKDIR "/src/StudyProject.Webapi"
RUN dotnet build "StudyProject.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyProject.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyProject.Webapi.dll"]