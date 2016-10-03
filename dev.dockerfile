FROM microsoft/dotnet
EXPOSE 5000
VOLUME "/var/www"
ENV ASPNETCORE_URLS http://+:5000
ENTRYPOINT /bin/bash