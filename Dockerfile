FROM mcr.microsoft.com/dotnet/sdk
WORKDIR /user/

# copy csproj and restore as distinct layers
COPY COVIDBlazorApp/ .
RUN dotnet restore

# build app
EXPOSE 5000
CMD ["dotnet", "run", "--urls=http://0.0.0.0:5000", "BlazorApp1.csproj"]
