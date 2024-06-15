#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Presentation/FerchauTest.Presentation.WebApi/FerchauTest.Presentation.WebApi.csproj", "Src/Presentation/FerchauTest.Presentation.WebApi/"]
COPY ["SharedKernel/FerchauTest.Shared/FerchauTest.Shared.csproj", "SharedKernel/FerchauTest.Shared/"]
COPY ["Src/Application/FerchauTest.Application/FerchauTest.Application.csproj", "Src/Application/FerchauTest.Application/"]
COPY ["Src/Domain/FerchauTest.Domain/FerchauTest.Domain.csproj", "Src/Domain/FerchauTest.Domain/"]
COPY ["Src/Domain/FerchauTest.Domain.Contract/FerchauTest.Domain.Contract.csproj", "Src/Domain/FerchauTest.Domain.Contract/"]
COPY ["Src/Infrastructure/Persistence/FerchauTest.Persistence.EntityFramework/FerchauTest.Persistence.EntityFramework.csproj", "Src/Infrastructure/Persistence/FerchauTest.Persistence.EntityFramework/"]
COPY ["Src/Application/FerchauTest.Application.Contract/FerchauTest.Application.Contract.csproj", "Src/Application/FerchauTest.Application.Contract/"]
RUN dotnet restore "./Src/Presentation/FerchauTest.Presentation.WebApi/FerchauTest.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/Presentation/FerchauTest.Presentation.WebApi"
RUN dotnet build "./FerchauTest.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FerchauTest.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FerchauTest.Presentation.WebApi.dll"]