FROM mcr.microsoft.com/dotnet/sak
WORKDIR /user/
COPY *.sln .
COPY *.csproj .
RUN dotnet restore

EXPOSE 5000
CMD ["dotnet", "run", "--urls=http://0.0.0.0:5000", "BlazorApp1.csproj"]
