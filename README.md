# E-Commerce REST API in .NET Core

[نسخه فارسی این سند](README.fa.md)

A robust REST API implementation for e-commerce applications built with .NET Core. This API provides endpoints for managing products, orders, customers, and authentication.

## Features

- 🛍️ Product management (CRUD operations)
- 🛒 Shopping cart functionality
- 👤 User authentication and authorization
- 📦 Order processing and management
- 💳 Basic payment integration
- 🔐 Secure API endpoints with JWT authentication

## Prerequisites

- .NET Core SDK 6.0 or later
- SQL Server (LocalDB or higher)
- Visual Studio 2019/2022 or VS Code

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/mohammadnazarkhani/E-Commerce-NETCore-REST-API.git
   cd E-Commerce-NETCore-REST-API
   ```

2. Navigate to the solution directory:

   ```bash
   cd ECommerceSln
   ```

3. Restore project dependencies:

   ```bash
   dotnet restore
   ```

4. Update the database:

   ```bash
   dotnet ef database update
   ```

5. Start the project:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` by default.

## API Documentation

API documentation is available at `/swagger` endpoint when running the application. For detailed documentation, check the [docs](./docs) directory.

## Contributing

Contributions are welcome! Whether it's:

- 🐛 Bug fixes
- ✨ New features
- 📝 Documentation improvements
- 🎨 UI/UX enhancements

Please read our [Contributing Guidelines](./CONTRIBUTING.md) before submitting a PR.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
