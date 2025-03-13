# API Documentation

## Endpoints

### Get All Products

- **URL**: `/api/products`
- **Method**: `GET`
- **Response**:
    ```json
    [
        {
            "id": 1,
            "name": "Product 1",
            "description": "Description of Product 1",
            "price": 100.00,
            "imageUrl": "http://example.com/image1.jpg"
        },
        ...
    ]
    ```

### Get Product by ID

- **URL**: `/api/products/{id}`
- **Method**: `GET`
- **Response**:
    ```json
    {
        "id": 1,
        "name": "Product 1",
        "description": "Description of Product 1",
        "price": 100.00,
        "imageUrl": "http://example.com/image1.jpg"
    }
    ```

### Create New Product

- **URL**: `/api/products`
- **Method**: `POST`
- **Request**:
    ```json
    {
        "name": "New Product",
        "description": "Description of the new product",
        "price": 150.00,
        "imageUrl": "http://example.com/image.jpg"
    }
    ```
- **Response**:
    ```json
    {
        "id": 3
    }
    ```