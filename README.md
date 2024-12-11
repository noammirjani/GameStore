# 🎮 GameStore

## Introduction

GameStore is a web application for managing and selling video games. It provides a platform for users to browse, purchase, and review games. Currently, it is a backend system that can be tested using tools like Postman or HTTP files to interact with the API endpoints.

## 📑 Table of Contents

- [Introduction](#introduction)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

## 🛠️ Technologies Used

- **Backend API:** ASP.NET Core
- **Database:** Entity Framework Core with SQLite
- **Testing:** Postman, HTTP files
- **Version Control:** Git
- **Development Environment:** Visual Studio Code

## 🚀 Getting Started

To get started with the GameStore project, follow these steps:

1. **Install .NET SDK:** Download from the [official .NET website](https://dotnet.microsoft.com/download).
2. **Install SQLite:** Ensure it is available on your system.
3. **Configure Database:** Set up your database connection string in the `appsettings.json` file.
4. **Run Migrations:** Set up the database schema:
    ```bash
    dotnet ef database update
    ```
5. **Build Project:** 
    ```bash
    dotnet build
    ```

## 🌟 Features

- **Game Browsing:** Explore a wide selection of video games.
- **User Management:** User authentication and profile management.
- **Shopping Cart:** Add games to a shopping cart and proceed to checkout.
- **Reviews and Ratings:** Leave reviews and ratings for purchased games.

## 🛠️ Installation

To install the GameStore project, follow these steps:

1. **Clone Repository:**
    ```bash
    git clone https://github.com/yourusername/GameStore.git
    ```
2. **Navigate to Directory:**
    ```bash
    cd GameStore
    ```
3. **Restore Dependencies:**
    ```bash
    dotnet restore
    ```

## ▶️ Usage

To run the application, use one of the following commands:

```bash
dotnet run --project GameStore.Api/GameStore.Api.csproj
```
or 
```bash
cd GameStore.Api
dotnet run 
```

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
