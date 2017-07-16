# WHA Tech Challenge
Working application hosted in:
http://whatechchallenge-randal.southeastasia.cloudapp.azure.com/

## Running with Docker
1. Make sure Docker is installed.
2. Go to the root directory and run
```
docker-compose up -d
```
3. Wait for the download of images to complete
4. Access the site at `http://localhost:8001`
## Running Manually
### Running the ASP.NET Core App
1. Make sure .NET Core SDK is installed
2. Make sure `appsettings.json` has it's `Endpoints` values pointing to the correct endpoints.
3. Navigate to `WHATechChallenge.Api` directory
4. Run the following command
```
dotnet run
```
5. Api will be available in `http://localhost:5000`

### Running the Angular App
1. Make sure Node is installed (at least version 6)
2. Navigate to `WHATechChallenge.FrontEnd` directory
3. Run this command
```
ng serve
```
4. Site will be available at `http://localhost:4200`.
## Running the Unit Tests
1. Navigate to `WHATechChallenge.Api.Tests` directory
2. Run this command
```
dotnet test
```