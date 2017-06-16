FROM microsoft/dotnet:latest
COPY artifacts/ /root/
COPY wwwroot/ /root/wwwroot
COPY Views/ /root/Views
COPY node_modules/ /root/node_modules
COPY app.json /root/app.json
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://+:5000
WORKDIR /root
ENTRYPOINT dotnet ./DotNetLibraryDemo.dll