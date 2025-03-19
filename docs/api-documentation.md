# API Documentation

## Product Endpoints

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
    "price": 100.0,
    "imageUrl": "http://example.com/image1.jpg",
    "categoryId": 1
  }
  ```

### Get Products by Category

- **URL**: `/api/products/category/{categoryId}`
- **Method**: `GET`
- **Response**:
  ```json
  [
    {
      "id": 1,
      "name": "Product 1",
      "description": "Description of Product 1",
      "price": 100.0,
      "imageUrl": "http://example.com/image1.jpg",
      "categoryId": 1
    }
  ]
  ```

### Create New Product

- **URL**: `/api/products`
- **Method**: `POST`
- **Request**:
  ```json
  {
    "name": "New Product",
    "description": "Description of the new product",
    "price": 150.0,
    "imageUrl": "http://example.com/image.jpg"
  }
  ```
- **Response**:
  ```json
  {
    "id": 3
  }
  ```

### Update Product

- **URL**: `/api/products`
- **Method**: `PUT`
- **Request**:
  ```json
  {
    "id": 1,
    "name": "Updated Product Name",
    "description": "Updated description",
    "price": 150.0,
    "imageUrl": "http://example.com/updated-image.jpg"
  }
  ```
- **Response**:
  - Success: 204 No Content
  - Not Found: 404 if product doesn't exist
  - Bad Request: 400 if request data is invalid

**Note**: All fields except `id` are optional. Only provided fields will be updated.

### Delete Product

- **URL**: `/api/products/{id}`
- **Method**: `DELETE`
- **Response**:
  - Success: 204 No Content
  - Not Found: 404 if product doesn't exist

## Category Endpoints

### Get All Categories

- **URL**: `/api/categories`
- **Method**: `GET`
- **Response**:
  ```json
  [
    {
      "id": 1,
      "name": "Category 1"
    },
    {
      "id": 2,
      "name": "Category 2"
    }
  ]
  ```

### Get Category by ID

- **URL**: `/api/categories/{id}`
- **Method**: `GET`
- **Response**:
  ```json
  {
    "id": 1,
    "name": "Category 1"
  }
  ```

### Create Category

- **URL**: `/api/categories`
- **Method**: `POST`
- **Request**:
  ```json
  {
    "name": "New Category"
  }
  ```
- **Response**:
  ```json
  {
    "id": 3
  }
  ```

### Update Category

- **URL**: `/api/categories`
- **Method**: `PUT`
- **Request**:
  ```json
  {
    "id": 1,
    "name": "Updated Category Name"
  }
  ```
- **Response**:
  - Success: 204 No Content
  - Not Found: 404 if category doesn't exist
  - Bad Request: 400 if request data is invalid

### Delete Category

- **URL**: `/api/categories/{id}`
- **Method**: `DELETE`
- **Response**:
  - Success: 204 No Content
  - Not Found: 404 if category doesn't exist
