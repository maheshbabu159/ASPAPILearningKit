# ASPAPILearningKit

ASPAPILearningKit has the implementation to create apis using .Net ASP Core.

![Demo](demo.gif)


## Features

- Install Docker
- Install Azure Data Studio
- Create a Project 
- Asynchronous image loading with progress indicators.
- Accessibility features such as labels and hints for improved user experience.

## Screenshots

<p align="center">

<img src="search.png" alt="" width="350" height="600">
<img src="search_results.png" alt="" width="350" height="600">
<img src="details.png" alt="" width="350" height="600">

</p>
## Requirements

- Xcode 12.0 or later.
- iOS 14.0 or later.
- Docker
- Azure data studio
- VS Code
- .NET ASP Core

## Setup
1. **SQL Server on Mac**:
    
        $ docker pull mcr.microsoft.com/azure-sql-edge
        
        $ docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=reallyStrongPwd123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
        
        $ docker container ls

        # To stop use following command
        $ docker container stop container_id

2. **Connect with Azure Data Studio**: Open Azure Data Studio, and using the “Create a Connection” option, enter the following details:

        Server: localhost
        Username: SA
        Password: reallyStrongPwd123

3. **Create project**: 

        $ dotnet new webapi --use-controllers -o ASPAPILearningKit
        $ cd ASPAPILearningKit
        $ dotnet add package Microsoft.EntityFrameworkCore.InMemory
        $ code -r ../ASPAPILearningKit

4. **SSL**:

        $ dotnet dev-certs https --trust

5. **Build**:

        $ dotnet run --launch-profile https

5. **Packages**:

        $ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        $ dotnet add package Microsoft.EntityFrameworkCore.Tools
        # Create models for tables
        $ dotnet ef dbcontext scaffold \
                        "Server=localhost,1433;Database=tempdb;User Id=sa;Password=Narasimha@2025;Encrypt=False;TrustServerCertificate=True;" \
                        Microsoft.EntityFrameworkCore.SqlServer \
                        -o Models -f


        $ dotnet aspnet-codegenerator controller \
                        -name CustomersController \
                        -m Customer \
                        -dc TempdbContext \
                        -outDir Controllers \
                        -api \
                        -async

## Project Structure

### Main Components:
1. **ContentView.swift**: The main view containing the search bar and displaying the list of photos in a grid.
2. **FlickrViewModel.swift**: The view model responsible for handling the search query and fetching photos from the Flickr API.
3. **NetworkManager.swift**: A network manager that handles API requests to fetch photos from the Flickr API.
4. **FlickrPhoto.swift**: A data model representing a photo from the Flickr API.
5. **SearchBar.swift**: A custom view that displays a text field for searching images.
6. **DetailView.swift**: A view that displays detailed information about a selected photo.
7. **FlickrSearchTests.swift**: Unit tests for verifying the functionality of the app.

## How to Run the App

1. Clone the repository:

2. Open the project in Xcode.

3. Build and run the app on a simulator or physical device.

        https://localhost:5043/
        https://localhost:5043/swagger/
        https://localhost:5043/openapi/v1.json

## API

The app fetches photos from the public Flickr API. The request URL is:

### Example API Response:

```json
{
    "title": "Sample Photo",
    "media": {"m": "https://example.com/photo.jpg"},
    "author": "John Doe",
    "published": "2025-03-13T10:00:00Z",
    "description": "Sample description"
}
```

## Unit Tests

The app includes unit tests for validating the parsing of Flickr photo data and verifying that the search query updates the results correctly.

### To run the tests:

1. Open the project in Xcode.
2. Press `Command + U` to run the tests.

## Accessibility

The app is designed with accessibility in mind. The following features are implemented:

- **Search Bar**: A label and hint are provided for the search bar to assist users in identifying its purpose.
- **Image Thumbnails**: Each image thumbnail has an accessibility label describing the photo's title.
- **Loading Indicators**: Accessibility labels for loading indicators to describe the app’s state.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.