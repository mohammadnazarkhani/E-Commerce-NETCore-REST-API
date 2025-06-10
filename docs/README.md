# Documentation

This directory contains documentation for this E-Commerce REST API project. The documentation is organized to help developers understand the system architecture, database design, and API endpoints.

## Directory Structure

```
docs/
├── database/          # Database documentation and diagrams
│   ├── erd.drawio    # Source file for Entity Relationship Diagram
│   ├── erd.drawio.svg# Rendered ERD diagram
│   └── README.md     # Database documentation
└── README.md         # This file
```

## Documentation Sections

### Database Documentation

Located in the `database/` directory, this section includes:

- Complete Entity-Relationship Diagrams (ERD)
- Database schema documentation
- Data seeding information
- Entity relationships and constraints
- Migration guidelines

### API Documentation

The API documentation is available through Swagger/OpenAPI when running the application:

- Access at: `https://localhost:5001/swagger`
- Interactive API testing interface
- Detailed endpoint descriptions
- Request/response examples

### Configuration

Important configuration files:

- `ECommerce.RestAPI/appsettings.json` - Production configuration
- `ECommerce.RestAPI/appsettings.Development.json` - Development configuration
- `ECommerce.RestAPI/Properties/launchSettings.json` - Launch profiles

### Seed Data

Initial data files:

- `ECommerce.RestAPI/Resources/SeedData_Assets/province_city_iran.json` - Geographic data for Iran

## Contributing to Documentation

When contributing to the documentation:

1. Keep the ERD diagrams up to date with any database changes
2. Document any new API endpoints in Swagger
3. Update relevant README files
4. Include code examples where appropriate
5. Maintain both English and Farsi versions of user-facing documentation
