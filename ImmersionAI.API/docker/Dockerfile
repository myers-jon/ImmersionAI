FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

COPY scripts/startup.sh .
RUN chmod +x startup.sh

COPY api/*.dll ./

ENTRYPOINT ["./startup.sh"]