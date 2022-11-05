# Truelayer Tech Test - Pokemon Finder API

This tech test has been implemented in C# and .NET 6.0 using Visual Studio 2022 and tested on Windows 10.

## Running the API

After cloning this repository, you can run this project by opening a Powershell window inside the PokemonFinder.Api folder and running the ```dotnet run``` command.

The localhost port that displays in the Powershell window can then be used in [Postman](https://www.postman.com/downloads/) to make the api calls.

To view how to use the API, you can go to ht<span>tps</span>://localhost:[port]/swagger/index.html which will display the different API calls. This can also be used to test the API.

### Docker

With limited prior experience with Docker, an attempt was made to get the API running using Docker.

Using the command ```docker build -t pokemonfinder.api:latest .``` when having the Powershell window open in the PokemonFinder folder, this built the Docker Image.

Attempting to run the APi using the commnand ```docker run -p 8080:8080 pokemonfinder.api:latest pokemon``` does claim to allow the API to be run on localhost, but it seems I was unable to get the port running properly.

## Testing

Unit tests have been included as part of this project and can be found in the PokemonFinder.Tests folder of the repository.

These can be run inside [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) using Test Explorer

## Project Layout/Structure

This solution was created using the ASP .NET Core Web API template in Visual Studio and then structured in a way that prioritised readability and reusability.

The Core library contained classes that were used across all projects, and each API integration was put in its own project so that it was extendable and easy to find Models and Services etc for that integration.

The overall project was built with extendability in mind, for example, if other calls needed to be made to the PokeApi, this could easily be done by adding a new method to the PokemonService which will then make use of the RestClient that is already implemented. Likewise if there was a requirement for a new API to be introduced, a new project can be created in the Integrations solution folder and make use of the existing RestClient by inheriting from the IAPIRequest interface.
