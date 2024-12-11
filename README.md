# GameStore

## Table of Contents

- [Introduction](#introduction)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Future Enhancements](#future-enhancements)
- [License](#license)

## Introduction

GameStore is a backend system for managing video games. It provides RESTful API endpoints to enable functionalities such as browsing and updating games. The application can be tested using tools like Postman or HTTP files.

## Technologies Used

- **Framework:** ASP.NET Core
- **Database:** Entity Framework Core with SQLite
- **Testing Tools:** Postman, HTTP files
- **Version Control:** Git
- **IDE:** Visual Studio Code

## Installation

To get started with the GameStore project, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/noammirjani/GameStore.git
    ```
2. Navigate to the project directory:
    ```bash
    cd GameStore.Api
    ```
3. Restore the required dependencies:
    ```bash
    dotnet restore
    ```
4. Run the application:
    ```bash
    dotnet run
    ```

## Usage

To run the application locally, use the following command:
```bash
dotnet run
```
You can manually test this backend system using HTTP requests. Refer to the HTTP files included in the project or utilize Postman with the specified port for examples.

To access the GameStore application, open your web browser and navigate to `http://localhost:5192`.

## Future Enhancements

Planned features for future updates include:

- **Genre Enhancements:** Improved functionality for managing and categorizing game genres.
- **Frontend Development:** Build a user-friendly interface using Blazor for browsing and purchasing games.
- **Enhanced User Authentication:** Add features like OAuth and advanced user management.

## License

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE) file.
