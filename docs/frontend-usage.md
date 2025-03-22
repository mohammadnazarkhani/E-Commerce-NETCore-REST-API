# Frontend Usage

## Main Navigation Pages

### Home Page
- **URL**: `/`
- **Description**: Displays all products. Access through the "خانه" link or logo.

### Products by Category
- **URL**: `/product/category/:categoryId`
- **Description**: Shows products filtered by category. Access through:
  - Products dropdown in navbar
  - Category breadcrumb links
  - "مشاهده محصولات" button in categories list

### Product Details Page
- **URL**: `/product/:id`
- **Description**: Shows product details with edit/delete options

## Category Management

### Categories List
- **URL**: `/categories`
- **Description**: Lists all categories with options to:
  - View category products
  - Edit category
  - Delete category
  - Add new category

### Add Category
- **URL**: `/create/category`
- **Description**: Form to create a new category

### Edit Category
- **URL**: `/edit/category/:id`
- **Description**: Form to modify existing category

## Product Management

### Add Product
- **URL**: `/create/product`
- **Description**: Form to add new product with category selection

### Edit Product
- **URL**: `/edit/product/:id`
- **Description**: Form to modify existing product details