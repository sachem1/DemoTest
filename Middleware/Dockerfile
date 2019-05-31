FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 13945
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["../MiddlewareTest/MiddlewareTest.csproj", "../MiddlewareTest/"]
RUN dotnet restore "../MiddlewareTest/MiddlewareTest.csproj"
COPY . .
WORKDIR "/src/../MiddlewareTest"
RUN dotnet build "MiddlewareTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MiddlewareTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MiddlewareTest.dll"]