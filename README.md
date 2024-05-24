# API for Tasks 
This project is an API for managing tasks, implementing the repository pattern with Dependency Injection (DI) and Unit of Work, and using JWT for authentication.

## Features

- CRUD operations for tasks
- Repository pattern for data access
- Unit of Work for transaction management
- JWT authentication for secure API access

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT for authentication

## Project Structure

- **GenericRepository.cs**: Implements a generic repository for common data operations.
- **UsingRepositoryPatternWithDIP.cs**: Demonstrates using the repository pattern with Dependency Injection.
- **GenericRepositoryWithUnitOfWork.cs**: Combines the generic repository with the Unit of Work pattern for transaction management.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code
- SQL Server

### Setup Instructions

1. **Clone the Repository:**

    ```bash
    git clone (https://github.com/Shadi201711/API-ITI-Lab)
    cd API-ITI-Lab
    ```

2. **Update Configuration:**

    - Update the `appsettings.json` file with your SQL Server connection string and JWT settings.

3. **Database Setup:**

    - Run the following commands to apply migrations and create the database:

      ```bash
      dotnet ef database update
      ```

4. **Run the API:**

    ```bash
    dotnet run
    ```

### JWT Authentication

To access the API, you need to include a valid JWT token in the Authorization header of your requests.

1. **Generate a Token:**

    - Use the `/api/auth/login` endpoint with valid credentials to receive a JWT token.

2. **Include the Token in Requests:**

    - Add the following header to your API requests:
      ```
      Authorization: Bearer YOUR_JWT_TOKEN
      ```

## API Endpoints

- `POST /api/auth/login` - Authenticate and receive a JWT token
- `GET /api/tasks` - Retrieve all tasks (requires JWT)
- `GET /api/tasks/{id}` - Retrieve a task by ID (requires JWT)
- `POST /api/tasks` - Create a new task (requires JWT)
- `PUT /api/tasks/{id}` - Update an existing task (requires JWT)
- `DELETE /api/tasks/{id}` - Delete a task (requires JWT)

## Usage

### Generic Repository

The `GenericRepository` class provides common data operations such as:

- `GetAll()`
- `GetById(id)`
- `Add(entity)`
- `Update(entity)`
- `Delete(id)`

### Using Repository Pattern with DIP

The `UsingRepositoryPatternWithDIP` class demonstrates dependency injection for repositories, allowing for easier testing and maintenance.

### Generic Repository with Unit of Work

The `GenericRepositoryWithUnitOfWork` class ensures that multiple operations can be committed as a single transaction, providing better control over data consistency.


