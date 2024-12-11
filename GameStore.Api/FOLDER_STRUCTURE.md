# 🎮 GameStore Project Structure

This document provides an overview of the folder and file structure of the GameStore project, explaining the purpose of each folder and its contents.

## 📂 Folder Structure

### **`Config`**
Stores configuration files for the application.
- `appsettings.json`: Main configuration file.
- `appsettings.Development.json`: Configuration file for the development environment.

### **`DTOs`**
This folder contains Data Transfer Objects (DTOs) used for transferring structured data between the API and its consumers.
- `CreateGameDto.cs`: DTO for creating a new game.
- `GameDetailsDto.cs`: DTO for detailed game information.
- `GameSummaryDto.cs`: DTO for summarizing game data.
- `GenreDto.cs`: DTO for genre information.
- `UpdateFieldGameDto.cs`: DTO for partial updates to a game.
- `UpdateGameDto.cs`: DTO for full updates to a game.

### **`Data`**
Holds database-related files and configurations.
- `GameStore.db`: The SQLite database file.
- `GameStoreContext.cs`: The Entity Framework Core database context.
- `DataExtensions.cs`: Helper methods for data operations.
- `Migrations/`: Contains migration files for database schema management.
  - `20241211114645_SeedGenres.cs`: Migration for seeding the Genres table.
  - `20241211114645_SeedGenres.Designer.cs`: Designer file for the migration.
  - `GameStoreContextModelSnapshot.cs`: Snapshot of the database schema.

### **`Endpoints`**
Defines the API endpoints for different features of the application.
- `GameEndpoints.cs`: Contains endpoints for game-related operations.
- `GenresEndpoints.cs`: Contains endpoints for genre-related operations.

### **`Entities`**
Contains the domain models representing database entities.
- `Game.cs`: Represents a video game entity.
- `Genre.cs`: Represents a genre entity.

### **`Mapping`**
Handles the mapping logic between DTOs and entities, often using extension methods.
- `GameMapping.cs`: Maps between `Game` entities and their DTOs.
- `GenresMapping.cs`: Maps between `Genre` entities and their DTOs.

### **`Properties`**
Contains configuration files specific to the development environment.
- `launchSettings.json`: Configuration for debugging and application launch settings.

### **`Tests`**
Contains files for testing the API endpoints.
- `Genres.http`: HTTP request file for testing genre-related endpoints.
- `Games.http`: HTTP request file for testing game-related endpoints.

### **Generated Folders**
- **`bin/`**: Contains compiled binaries and executable files.
- **`obj/`**: Stores temporary files during the build process.

## 🗂️ Key Files
- **`Program.cs`**: The entry point of the application where the API is configured and started.
- **`GameStore.Api.csproj`**: The project file defining dependencies and build settings.

---

For any issues or contributions, feel free to create a pull request or open an issue on the repository.
