<div align="center">
	<h1 align="center">
	    <img height="120" width="120" alt=".NET Core" src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/2048px-.NET_Core_Logo.svg.png"/>
        <img height="120" width="120" alt=".NET Core" src="https://user-images.githubusercontent.com/34761298/232374189-d271565d-1388-4427-a0be-8742d7c67dce.jpg"/>
	</h1>
</div>

# OpenAi Web MVC Application + Web API .NET

This project provides a simple .NET MVC Web Application + .NET Core API to generate images from an text using OpenAi library .NET.

## Requirements

- SDK .NET 7.0 or later
- Docker

## Installation Web App (MVC Solution)

```bash
# Clone the repository
git clone https://github.com/cerqueirav/openai-web-app

# Navigate to the project directory
cd openai-web-app/GptWeb

# Install the dependencies (using NuGet or CMD)
- Newtonsoft Json 13.0.3 or later
- Microsoft Visual Studio Azure Containers Tools Targets 1.17.0 or later

# Run the Web Aplicattion
dotnet run or run through visual studio
```

## Installation Web Api (API Solution)

```bash
# Clone the repository
git clone https://github.com/cerqueirav/openai-web-app

# Navigate to the project directory
cd openai-web-app/GptApi

# Install the dependencies (using NuGet or CMD)
- Microsoft AspNetCore OpenApi 7.0.2 or later
- Microsoft Visual Studio Azure Containers Tools Targets 1.17.0 or later
- OpenAi-DotNet 6.7.1 or later
- Swashbuckle AspNetCore 6.4.0 or later

# Run the Web API
dotnet run or run through visual studio

## Documentation

```bash
POST https://localhost:44391/images/create
```

The request body must be a JSON object with the following field:

- title (required): The text you want to create image.
- qty (required): The number of images that will be generated
- size (optional): The size of the images that will be generated

Example:

```json
{
    "title": "Cat Yellow",
    "qty": 2
}
```

The response will be a list of qty size images related to the searched title
