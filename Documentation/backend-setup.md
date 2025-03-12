# Backend Setup

## Prerequisites

- .NET 6 SDK
- SQL Server

## Setup Instructions

1. Clone the repository:
    ```sh
    git clone <repository-url>
    cd TondForoosh/TondForooshApi
    ```

2. Update the connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "SqlServerConnection": "Server=<your-server>;Database=TondForooshDb;Trusted_Connection=True;"
    }
    ```

3. Apply migrations and seed the database:
    ```sh
    dotnet ef database update
    ```

4. Run the API:
    ```sh
    dotnet run
    ```

## API Endpoints

- `GET /api/products`: Get all products
- `GET /api/products/{id}`: Get a product by ID
- `POST /api/products`: Create a new product