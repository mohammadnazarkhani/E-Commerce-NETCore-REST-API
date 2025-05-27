# MockSmsProvider

This small project simulates an SMS provider system for the TondForoosh project. The system allows users to log in using a phone number or a name (string) as their identifier and view messages in their inbox. It also provides a REST API for sending messages to other users.

[Persian Version (نسخه فارسی)](./README.md)

## Features

- User authentication with phone number or name
- View inbox messages
- Send SMS to other users via REST API
- SQLServer database for message storage

## Setup and Installation

### Prerequisites

- .NET 9.0 SDK
- SQL Server (or Docker with SQL Server)
- dotnet-ef tool

### Installation Steps

1. Clone the repository
2. Navigate to the project directory
3. Restore packages:

   ```bash
   dotnet restore
   ```

4. Install Entity Framework Core tools:

   ```bash
   # Check current version
   dotnet ef --version

   # If needed, update to compatible version (9.0.5)
   dotnet tool uninstall --global dotnet-ef
   dotnet tool install --global dotnet-ef --version 9.0.5
   ```

5. Configure the database:

   - Check `appsettings.json` for the connection string
   - Default configuration works with local SQL Server instance
   - Apply database migrations:
     ```bash
     dotnet ef database update
     ```
     Note: You can configure any SQL Server instance or use Docker

6. Run the application:
   ```bash
   dotnet run
   ```

## Database Schema

The Entity Relationship Diagram below shows the database structure:

![Database ERD](../docs/MockSmsProvider/database/erd.drawio.svg)

## Screenshots

Here's how the application looks:

![Application Screenshot](./Screenshot.png)

## API Documentation

Coming soon...
