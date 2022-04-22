# **Travel API ™️**

#### _An API for TRAVEL. A user may View List, Add, Edit, and Delete Destinations as needed and interact with the the API using Postman._

#### Authored by **Cesar Lopez, Chris Nakayama, Wajima Niazi, Ebru Rice, Amber Wilwand**

## Technologies Used
- C#
- MySQL
- My SQL Workbench
- VS Code
- Git BASH
- LINQ
- ASP .NET CORE MVC
- Entity Framework Core
- Postman
- Swagger
- Swashbuckle

## Setup/Installation Requirements

### Clone the project
- Open the terminal on your local computer.
- Navigate to the parent directory of your preference.
- Clone this project using `$ git clone https://github.com/wowgr8/TravelApi.solution`
- Navigate to the directory: ```$ cd TravelApi.Solution```
- Open in Vs code: ```$ code .```

### Create the database
- Navigate to TravelApi: ```$ cd TravelApi``` and type the following command in the terminal ```$ touch appsettings.json```
- Navigate to the appsettings.json file ```$ cd appsettings.json``` and enter:
```
{
  "Logging":
  {
    "LogLevel":
    {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings":
  {
    "DefaultConnection": "Server=localhost;Port=3306;database=travel_api;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
- If you haven't installed dontet ef tool, install it by running the command ```$ dotnet tool install --global dotnet-ef --version 3.0.0```
- Run the command ```$ dotnet ef migrations add Initial``` to create a migration in Factory folder.
- Run the command ```$ dotnet ef database update``` to apply migrations.
- Be sure to remove the {YOUR_PASSWORD-HERE} and fill in the the code snippet with your username for MySQL password. Do not include the curly brackets in your code snippet of appsettings.json

### Run the project

- Run ```$ dotnet restore``` in the git BASH terminal to install needed dependencies.
- Run ```$ dotnet build``` in the git BASH terminal to minify the code. 
- Run ```$ dotnet run``` in the git BASH terminal to run the project in the terminal.
- View the API by downloading Postman and entering http://localhost:5000/ as a GET!

### API Documentation

API Endpoints
HTTP Request URL: http://localhost:5000

#### General request structure:

- GET /api/Destinations
- POST /api/Destinations
- GET /api/Destinations/{id}
- PUT /api/Destinations/{id}
- DELETE /api/Destinations/{id} 
- Examples of a request URL query string: https://localhost:5001/api/Destinations

#### Documentation utilized for further explorations:

Swagger source: microsoft docs
Swagger utilizing Swashbuckle source: microsoft docs

## Known Bugs
- _None._

## License
[MIT License](https://opensource.org/licenses/MIT) © 2022

## Contact
If any issues are discovered while navigating the site, please let us know! It will help us learn and grow!
[cnakayam@gmail.com](mailto:cnakayam@gmail.com)
