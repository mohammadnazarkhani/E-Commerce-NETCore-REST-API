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
- `GET /api/product`: Get all products
- `GET /api/product/{id}`: Get product by ID
- `GET /api/product/category/{categoryId}`: Get products by category
- `POST /api/product`: Create new product
- `PUT /api/product/{id}`: Update product
- `DELETE /api/product/{id}`: Delete product

### Category Endpoints
- `GET /api/category`: Get all categories
- `GET /api/category/{id}`: Get category by ID
- `POST /api/category`: Create new category
- `PUT /api/category/{id}`: Update category
- `DELETE /api/category/{id}`: Delete category

## Data Models

### Product
```json
{
  "id": 1,
  "name": "Product Name",
  "description": "Product Description",
  "price": 100.00,
  "imageUrl": "https://example.com/image.jpg",
  "categoryId": 1,
  "categoryName": "Category Name"
}
```

### Category
```json
{
  "id": 1,
  "name": "Category Name"
}
```