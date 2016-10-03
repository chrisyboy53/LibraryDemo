FROM microsoft/dotnet:latest

ENV ASPNETCORE_URLS http://+:5000
VOLUME /var/www
WORKDIR /var/www
EXPOSE 5000
# Just run the service in bash to allow developers to jump into it
ENTRYPOINT /bin/bash