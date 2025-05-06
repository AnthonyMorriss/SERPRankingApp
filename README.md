# InfoTrack Search Engine Result Ranking Project

This application is built on **.NET 9**. The App is designed to allow for scraping of the google search engine, checking for hits on a given URL.

## Features
- The app allows for scraping google search engine using a search term and URL to search for.
- The app allows for scraping of a local saved html file, in  the event google is blocking the scraping of its search engine from external apps.

## Getting Started
1. **Clone the repository**.
2. **Setup Database**
   - Ensure the DatabaseConnectionString in the ```AppSettings.Json``` located in the API project is set correctly for your environment.
   - The default value used for testing is:
```
"DatabaseConnectionString": "Server=(localdb)\\mssqllocaldb;Database=db_serprankingapp;Trusted_Connection=True;MultipleActiveResultSets=true"
```
- In Visual Studio, Open the package manager console.
- Ensure the default project in the console is set to 'SERPRankingApp.Persistance'.
- Run the command: ```update-database```

3. **Starting Application**
- Open the console and navigate to the API project.
  ```cd SERPRankingApp.API```
- Execute command:
  ```dotnet run```
- In a new console, navigate to the UI project
  ```cd SERPRankingApp.UI```
- Execute command:
  ```dotnet run```
- The Font end should be available at 'http://localhost:5124/'

# Using Google Search HTML File Saved Locally
- Open the developer tab in the browser (F12).
- Use this URL: https://www.google.co.uk/search?num=100&q=
- Add the Search terms required replacing spaces ' ' with '+'.
- Search this URL and save the response of the first network request locally.
- Provide this file location to the app when 'Use HTML File' is checked.

## Tech
- **Blazor WebAssembly**: Frontend built with Blazor WebAssembly.
- **.NET 9**.
- **Clean Architecture**: Organized into distinct layers.
  - **Domain**: Core business logic and entities.
  - **Application**: Application-specific logic.
  - **Infrastructure**: External integrations and third-party services.
  - **Persistence**: Data access.
  - **UI**: Interface to search and retrieve results.
