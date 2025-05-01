## syntax=docker/dockerfile:1
#
## שלב הבנייה
#FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
#
#WORKDIR /source
#
#COPY . . 
##COPY ./Api ./Api
#
#WORKDIR /source/Api
#
#ARG TARGETARCH
#
#
##RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    ##dotnet publish Api.csproj -c Release -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app
#
#RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    #dotnet publish -c Release -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app
##
    ##RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    ##dotnet publish Api.csproj -c Release -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app
#
## שלב ההרצה
#FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
#
#WORKDIR /app
#
#COPY --from=build /app .
#
## יצירת משתמש לא-שורש
#RUN adduser -D appuser
#USER appuser
#
## חשיפת הפורט והגדרת ASPNETCORE_URLS ל-HTTP על פורט 80
#ENV ASPNETCORE_URLS=http://+:80
#EXPOSE 80
#
## קביעת הפקודה להרצה
#ENTRYPOINT ["dotnet", "Api.dll"]
#-----------------------------------------

# syntax=docker/dockerfile:1

# שלב הבנייה
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source

# מעתיק את כל הקבצים כולל Api.csproj
COPY . .

ARG TARGETARCH

# פרסום הפרויקט
RUN dotnet publish Api.csproj -c Release -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

# שלב ההרצה
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

COPY --from=build /app .

# יצירת משתמש לא-שורש
RUN adduser -D appuser
USER appuser

# חשיפת הפורט והגדרת ASPNETCORE_URLS ל-HTTP על פורט 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# קביעת הפקודה להרצה
ENTRYPOINT ["dotnet", "Api.dll"]
