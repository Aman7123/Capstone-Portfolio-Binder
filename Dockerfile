FROM mcr.microsoft.com/dotnet/sak
WORKDIR /user/
COPY *.sln .
COPY *.csproj .
RUN dotnet restore

EXPOSE 5500
RUN dotnet run --urls=http://0.0.0.0:5500 BlazorApp1.csproj
