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

### Product Endpoints
- `GET /api/products`: Get all products
- `GET /api/products/{id}`: Get a product by ID
- `GET /api/products/category/{categoryId}`: Get products by category
- `POST /api/products`: Create a new product
- `PUT /api/products`: Update an existing product
- `DELETE /api/products/{id}`: Delete a product by ID

### Category Endpoints
- `GET /api/categories`: Get all categories
- `GET /api/categories/{id}`: Get a category by ID
- `POST /api/categories`: Create a new category
- `PUT /api/categories`: Update an existing category
- `DELETE /api/categories/{id}`: Delete a category by ID